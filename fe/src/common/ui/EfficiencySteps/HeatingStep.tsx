import { LocalFireDepartment } from "@mui/icons-material";
import {
  Avatar,
  Checkbox,
  CssBaseline,
  FormControlLabel,
  Typography,
} from "@mui/material";
import {
  EnergyEfficiencyInputModel,
  HeaterFactors,
  OuterEnclosureHeatLoss,
  SeasonalHeaterOptions,
  SeasonalOptionsWithNoDating,
  TemperatureComponents,
  TemperatureDifferenceOptions,
  TemperatureRegulationOptions,
} from "../../interfaces";
import StepDropDown from "./StepDropDown";
import YearlyNumbers from "./YearlyNumbers";
import RangeSlider from "./NumberField";
import "./steps.css";
import InfoTooltip from "../InfoTooltip";
import { produce } from "immer";

interface HeatingStepProps {
  data: EnergyEfficiencyInputModel;
  setData: (data: EnergyEfficiencyInputModel) => void;
}

const HeatingStep: React.FC<HeatingStepProps> = (props) => {
  const { data, setData } = props;

  const getTemperatureComponentDropDown = () => {
    return (
      <StepDropDown
        setData={(event) =>
          setData({
            ...data,
            temperatureComponentType: event.target.value,
            temperaturDifference:
              (event.target.value as TemperatureComponents) ===
              TemperatureComponents.TemperatureDifference
                ? TemperatureDifferenceOptions.K30
                : TemperatureDifferenceOptions.None,
            regulationOptions:
              (event.target.value as TemperatureComponents) ===
              TemperatureComponents.TemperatureRegulation
                ? TemperatureRegulationOptions.Absent
                : TemperatureRegulationOptions.None,
            heatLoss:
              (event.target.value as TemperatureComponents) ===
              TemperatureComponents.OuterEnclosureHeatLoss
                ? OuterEnclosureHeatLoss.HeaterNearInnerWall
                : OuterEnclosureHeatLoss.None,
          })
        }
        label={"Впливовий фактор ефективності нагрівальних поверхонь"}
        value={data.temperatureComponentType}
        menuItems={[
          {
            value: TemperatureComponents.TemperatureRegulation,
            label: "Регулювання температури повітря приміщення",
            underContent: (
              <StepDropDown
                setData={(event) =>
                  setData({
                    ...data,
                    regulationOptions: event.target.value,
                  })
                }
                label={"Тип регулювання"}
                value={data.regulationOptions}
                menuItems={[
                  {
                    value: TemperatureRegulationOptions.Absent,
                    label: "Відсутнє",
                  },
                  {
                    value:
                      TemperatureRegulationOptions.WhileAverageBuildingTemp,
                    label:
                      "За усередненої (характерної) температури повітря приміщень будівлі",
                  },
                  {
                    value: TemperatureRegulationOptions.PRegulation2K,
                    label: "П-регулювання (2 К)",
                  },
                  {
                    value: TemperatureRegulationOptions.PRegulation1K,
                    label: "П-регулювання (1 К)",
                  },
                  {
                    value: TemperatureRegulationOptions.PIRegulation,
                    label: "ПI-регулювання",
                  },
                  {
                    value: TemperatureRegulationOptions.PiRegulationOptimised,
                    label: "ПI-регулювання з оптимізацією",
                  },
                ]}
                tooltip={
                  <InfoTooltip
                    text={
                      "Відсутнє регулювання - температура підтримується на постійному рівні. Регулювання за усередненою температурою повітря - в залежності від середньої температури у приміщенні протягом дня. П-регулювання (2 К) - система вмикається або вимикається, коли температура перевищує або опускається на 2 °К. П-регулювання (1 °К): - аналогічне до попереднього, але різниця температур становить 1 °К"
                    }
                  />
                }
              />
            ),
          },
          {
            value: TemperatureComponents.TemperatureDifference,
            label: "Температурний напір (за температури повітря 20 °C)",
            underContent: (
              <StepDropDown
                setData={(event) =>
                  setData({
                    ...data,
                    temperaturDifference: event.target.value,
                  })
                }
                label={"Ступінь напору"}
                value={data.temperaturDifference}
                menuItems={[
                  {
                    value: TemperatureDifferenceOptions.K60,
                    label: ">= 60°",
                  },
                  {
                    value: TemperatureDifferenceOptions.K42,
                    label: "~ 42,5°",
                  },
                  {
                    value: TemperatureDifferenceOptions.K30,
                    label: "<= 30°",
                  },
                ]}
                tooltip={
                  <InfoTooltip
                    text={
                      "Різниця в температурі між поверхнею нагрівального пристрою і повітря середовища, °К"
                    }
                  />
                }
              />
            ),
          },
          {
            value: TemperatureComponents.OuterEnclosureHeatLoss,
            label: "Специфічні тепловтрати через зовнішні огородження",
            underContent: (
              <StepDropDown
                setData={(event) =>
                  setData({
                    ...data,
                    heatLoss: event.target.value,
                  })
                }
                label={"Тип тепловтрат"}
                value={data.heatLoss}
                menuItems={[
                  {
                    value: OuterEnclosureHeatLoss.HeaterNearInnerWall,
                    label:
                      "Опалювальний прилад установлено біля внутрішньої стіни",
                  },
                  {
                    value:
                      OuterEnclosureHeatLoss.HeaterNearOuterWallNoRadiationalProtection,
                    label: "Вікно без радіаційного захисту",
                  },
                  {
                    value:
                      OuterEnclosureHeatLoss.HeaterNearOuterWallWithRadiationalProtection,
                    label: "Вікно з радіаційним захистом",
                  },
                  {
                    value: OuterEnclosureHeatLoss.HeaterNearRegularOuterWall,
                    label:
                      "Опалювальний прилад установлено біля зовнішньої стіни: звичайна стіна",
                  },
                ]}
                tooltip={undefined}
              />
            ),
          },
        ]}
      />
    );
  };

  return (
    <>
      <CssBaseline />
      <Avatar sx={{ mt: 5, left: 190, bgcolor: "primary.light" }}>
        <LocalFireDepartment />
      </Avatar>
      <Typography mt={2} ml={8} variant="h5" width={400}>
        Опалення та коєфіцієнти
      </Typography>

      <div
        className="heating-container"
        style={{ position: "relative", top: 40, columnGap: 40 }}
      >
        <div className="item">
          <StepDropDown
            setData={(event) =>
              setData({
                ...data,
                seasonalHeaterType: event.target.value,
                heaterFactorFieldName: SeasonalOptionsWithNoDating.includes(
                  event.target.value
                )
                  ? HeaterFactors.Any
                  : HeaterFactors.After2008,
              })
            }
            label={"Джерело теплозабезпечення"}
            value={data.seasonalHeaterType}
            menuItems={SeasonalHeaterOptions}
          />

          {!SeasonalOptionsWithNoDating.includes(data.seasonalHeaterType) && (
            <StepDropDown
              setData={(event) =>
                setData({
                  ...data,
                  heaterFactorFieldName: event.target.value,
                })
              }
              label={"Дата випуску джерела теплозабезпечення"}
              value={data.heaterFactorFieldName}
              menuItems={[
                { value: HeaterFactors.Before1994, label: "До 1994" },
                {
                  value: HeaterFactors.From1994To2008,
                  label: "1994-2008",
                },
                {
                  value: HeaterFactors.After2008,
                  label: "Починаючи з 2008",
                },
              ]}
            />
          )}

          {getTemperatureComponentDropDown()}

          <div style={{ display: "flex", flexDirection: "row" }}>
            <FormControlLabel
              sx={{ mt: 2, ml: 7 }}
              control={
                <Checkbox
                  checked={data.isRadiantHeatingSystem}
                  value={data.isRadiantHeatingSystem}
                  onClick={(event) => {
                    const newData = {
                      ...data,
                      isRadiantHeatingSystem: !data.isRadiantHeatingSystem,
                    };
                    setData(newData);
                  }}
                />
              }
              label={"Теплова система є променевою"}
              value={data.isRadiantHeatingSystem}
            />
            <div style={{ marginLeft: "5px", marginTop: "25px" }}>
              <InfoTooltip text="Використовує промені тепла для нагрівання об'єктів та поверхонь в приміщенні, замість прямого нагрівання повітря." />
            </div>
          </div>
        </div>
        <div className="item">
          <YearlyNumbers
            label="Середня температура теплоносія щомісяця"
            values={data.avgYearlyHeatCarrierTemp}
            onUpdateValues={(input) =>
              setData({ ...data, avgYearlyHeatCarrierTemp: input })
            }
            minValue={0}
            maxValue={100}
            defaultValue={0}
            measuringUnits={"°C"}
          />
          <RangeSlider
            title={"Коефіцієнт ефективності генерації електроенергії"}
            min={0.01}
            max={1}
            value={data.electicityGenerationEfficiency}
            setData={(val: number) =>
              setData({ ...data, electicityGenerationEfficiency: val })
            }
            tooltip={
              <InfoTooltip
                text={
                  "Ефективність електричних теплогенеруючих установок будівлі"
                }
              />
            }
          />
          <RangeSlider
            title={"Річна енергія виходу для підсистеми розподілення"}
            min={100}
            max={5000}
            value={data.yearlyHeatingSubsystemExitEnergy}
            setData={(val: number) =>
              setData({ ...data, yearlyHeatingSubsystemExitEnergy: val })
            }
            measuringUnits="кВт×год"
            tooltip={
              <InfoTooltip
                text={
                  "Включає в себе всі компоненти, які забезпечують розподіл енергії всередині будівлі. "
                }
              />
            }
          />
        </div>
        <div className="item">
          <YearlyNumbers
            label="Середня температура довкілля  щомісяця"
            values={data.avgYearlyEnvironmentTemp}
            onUpdateValues={(input) =>
              setData({ ...data, avgYearlyEnvironmentTemp: input })
            }
            minValue={-50}
            maxValue={50}
            defaultValue={0}
            measuringUnits={"°C"}
          />
          <RangeSlider
            title={"Коефіцієнт ефективності генерації теплової енергії"}
            min={0.01}
            max={1}
            value={data.heatGenerationEfficiency}
            setData={(val: number) =>
              setData({ ...data, heatGenerationEfficiency: val })
            }
            tooltip={
              <InfoTooltip
                text={
                  "Вказує на ефективність процесу перетворення первинної енергії (наприклад, палива, сонячного випромінювання, вітру тощо) на електричну енергію"
                }
              />
            }
          />
        </div>
        <div className="item">
          <YearlyNumbers
            label="Середня кількість годин опалення в день"
            values={data.avgYearlyHeatingHours}
            onUpdateValues={(input) =>
              setData({ ...data, avgYearlyHeatingHours: input })
            }
            minValue={0}
            maxValue={12}
            defaultValue={0}
            measuringUnits={"год"}
          />
          <RangeSlider
            title={"Коефіцієнт використання надходжень для опалення"}
            min={0.01}
            max={2}
            value={data.heatingUsageFactor}
            setData={(val: number) =>
              setData({ ...data, heatingUsageFactor: val })
            }
            tooltip={
              <InfoTooltip
                text={
                  "Вказує на те, яка частина теплової енергії, яка надходить до будівлі (наприклад, від системи опалення, сонячних колекторів тощо), фактично використовується для опалення."
                }
              />
            }
          />
          <RangeSlider
            title={"Тариф на опалення, грн/ГКал"}
            min={1}
            max={10000}
            value={data.price}
            setData={(val: number) => setData({ ...data, price: val })}
          />
          <YearlyNumbers
            label={"Дані лічильника опалення щомісячно"}
            values={data.heatingConsumptionMonths}
            onUpdateValues={(values) =>
              setData(
                produce(data, (draft: EnergyEfficiencyInputModel) => {
                  draft.heatingConsumptionMonths = values;
                })
              )
            }
            minValue={0}
            maxValue={1000}
            defaultValue={0}
            measuringUnits="Гкал"
          />
        </div>
      </div>
    </>
  );
};

export default HeatingStep;
