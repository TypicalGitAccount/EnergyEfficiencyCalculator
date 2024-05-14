import React, { useEffect, useState } from "react";
import FormStepper from "../common/ui/Stepper";
import useAuthContext from "../common/hooks/useAuthContext";
import { Box, Button, CircularProgress } from "@mui/material";
import BuildingStep from "../common/ui/EfficiencySteps/BuildingStep";
import PipelineStep from "../common/ui/EfficiencySteps/PipelineStep";
import HeatingStep from "../common/ui/EfficiencySteps/HeatingStep";
import {
  EfficiencyClass,
  EfficiencyResultsModel,
  EnergyEfficiencyInputModel,
  EnergyMeterEfficiencyModel,
  getDefaultEfficiencyModel,
  getDefaultEnergyMeterModel,
} from "../common/interfaces";
import {
  getEnergyEfficiencyClass,
  getEnergyEfficiencyClassFromMeter,
  getPayments,
} from "../common/api";
import { toast } from "react-toastify";
import { useNavigate } from "react-router-dom";
import { motion } from "framer-motion";
import EfficiencyResults from "../common/ui/EfficiencySteps/EfficiencyResults";
import StartCalculation from "../common/ui/EfficiencySteps/StartCalculation";
import EnergyMeterForm from "../common/ui/EfficiencySteps/EnergyMeterForm";
import { Helmet } from "react-helmet";

interface LastCalcualtionData {
  input: EnergyEfficiencyInputModel | null;
  energyMeterInput: EnergyMeterEfficiencyModel | null;
  result: EfficiencyResultsModel;
  userId: string;
}

export enum CalculationMode {
  Specs,
  EnergyMeter,
}

const lastCalcKey = "lastCalculation";

const getFromLocalStorage = (userId: string) => {
  let item = window.localStorage.getItem(lastCalcKey);
  if (item !== "null" && item != null) {
    let obj = JSON.parse(item!);
    if (obj.userId === userId) {
      return obj;
    }
  }
  return null;
};

const setToLocalStorage = (item: LastCalcualtionData | null) => {
  window.localStorage.setItem(lastCalcKey, JSON.stringify(item));
};

const Efficiency: React.FC = () => {
  const { user, jwtTokens } = useAuthContext();
  const navigate = useNavigate();

  const [calculation, setCalculation] = useState(false);

  const [loading, setLoading] = useState(false);

  let lastCalculation: LastCalcualtionData = getFromLocalStorage(
    user?.id ?? ""
  );

  const [calculationMode, setCalculationMode] = useState<CalculationMode>(
    lastCalculation?.result.calculationMode ?? CalculationMode.EnergyMeter
  );
  const [data, setData] = useState<EnergyEfficiencyInputModel>(
    lastCalculation?.input ?? getDefaultEfficiencyModel()
  );
  const [energyMeterData, setEnergyMeterData] =
    useState<EnergyMeterEfficiencyModel>(
      lastCalculation?.energyMeterInput ?? getDefaultEnergyMeterModel()
    );
  const [results, setResults] = useState<EfficiencyResultsModel | null>(null);

  useEffect(() => {
    if (!user || !jwtTokens) {
      navigate("/login");
    }
  }, [user, jwtTokens]);

  const handleCalculation = async () => {
    if (calculationMode === CalculationMode.Specs) {
      setLoading(true);
      const response = await getEnergyEfficiencyClass(
        jwtTokens!.accessToken,
        data
      );
      const payments = await getPayments(jwtTokens!.accessToken, {
        heatingConsumptionMonths: data.heatingConsumptionMonths,
        price: data.price,
      });
      setLoading(false);
      if (typeof response === typeof {}) {
        toast.error(response);
      } else {
        setCalculation(false);
        setResults({
          class: response as EfficiencyClass,
          heatingPaymentsMonths: payments as number[],
          calculationMode: calculationMode,
          building: data.building,
        });
        setToLocalStorage({
          input: data,
          energyMeterInput: null,
          result: {
            class: response as EfficiencyClass,
            heatingPaymentsMonths: payments as number[],
            calculationMode: calculationMode,
            building: data.building,
          },
          userId: user?.id!,
        });
      }
    } else {
      setLoading(true);
      const response = await getEnergyEfficiencyClassFromMeter(
        jwtTokens!.accessToken,
        {
          efficiencyValue: energyMeterData.consumption,
          building: energyMeterData.building,
          tempZone: energyMeterData.tempZone,
          stories: energyMeterData.stories,
        }
      );
      const payments = await getPayments(jwtTokens!.accessToken, {
        heatingConsumptionMonths: energyMeterData.heatingConsumptionMonths,
        price: energyMeterData.price,
      });
      setLoading(false);
      if (typeof response === typeof {}) {
        toast.error(response);
      } else {
        setCalculation(false);
        setResults({
          class: response as EfficiencyClass,
          heatingPaymentsMonths: payments as number[],
          calculationMode: calculationMode,
          building: energyMeterData.building,
        });
        setToLocalStorage({
          input: null,
          energyMeterInput: energyMeterData,
          result: {
            class: response as EfficiencyClass,
            heatingPaymentsMonths: payments as number[],
            calculationMode: calculationMode,
            building: energyMeterData.building,
          },
          userId: user?.id!,
        });
      }
    }
  };

  const handleStartCalculation = () => {
    setData(getDefaultEfficiencyModel());
    setEnergyMeterData(getDefaultEnergyMeterModel());
    setCalculation(true);
    setResults(null);
  };

  const handleDropCalculation = () => {
    setCalculation(false);
    setData(getDefaultEfficiencyModel());
    setEnergyMeterData(getDefaultEnergyMeterModel());
    setResults(null);
    setToLocalStorage(null);
  };

  return (
    <motion.div
      initial={{ width: 0 }}
      animate={{ width: "100%" }}
      exit={{ x: window.innerWidth, transition: { duration: 0.01 } }}
    >
      <Helmet>
        <title>{"Калькулятор"}</title>
      </Helmet>

      {!loading ? (
        <>
          {!calculation && !results && !lastCalculation && (
            <StartCalculation
              handleStart={handleStartCalculation}
              calculationMode={calculationMode}
              setCalculationMode={setCalculationMode}
            />
          )}
          {!calculation && (results || lastCalculation) && (
            <>
              <EfficiencyResults
                payments={
                  results?.heatingPaymentsMonths ??
                  lastCalculation.result.heatingPaymentsMonths
                }
                efficiencyClass={results?.class ?? lastCalculation.result.class}
                buildingType={
                  results?.building ?? lastCalculation.result.building
                }
                toBuildingAdvices={() =>
                  navigate(
                    `/advices/${
                      results?.building ?? lastCalculation.result.building
                    }`
                  )
                }
                backToCalculationButton={
                  <Button
                    onClick={() => {
                      setCalculation(true);
                      setResults(null);
                    }}
                    variant="contained"
                  >
                    {"Редагувати розрахунок"}
                  </Button>
                }
                dropCalculation={handleDropCalculation}
              />
            </>
          )}

          {calculation && !results && (
            <div>
              <form>
                {calculationMode === CalculationMode.EnergyMeter ? (
                  <EnergyMeterForm
                    data={energyMeterData}
                    setData={setEnergyMeterData}
                    dropCalculation={handleDropCalculation}
                    onCalculation={handleCalculation}
                  />
                ) : (
                  <FormStepper
                    steps={[
                      {
                        value: <BuildingStep data={data} setData={setData} />,
                        label: "Характеристики будівлі",
                      },
                      {
                        value: <PipelineStep data={data} setData={setData} />,
                        label: "Охолодження та водопровід опалення",
                      },
                      {
                        value: <HeatingStep data={data} setData={setData} />,
                        label: "Опалення",
                      },
                    ]}
                    dropCalculation={handleDropCalculation}
                    onCalculation={handleCalculation}
                  />
                )}
              </form>
            </div>
          )}
        </>
      ) : (
        <CircularProgress
          sx={{
            position: "fixed",
            top: "50%",
            left: "50%",
            transform: "translate(-50%, -50%)",
          }}
        />
      )}
    </motion.div>
  );
};

export default Efficiency;
