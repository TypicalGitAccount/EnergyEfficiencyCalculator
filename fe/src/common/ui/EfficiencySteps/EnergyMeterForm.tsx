import * as React from "react";
import Box from "@mui/material/Box";
import { Avatar, Button, Container, Grid, Typography } from "@mui/material";
import Confirmation from "./../Confirmation";
import { MapsHomeWorkRounded } from "@mui/icons-material";
import NumberField from "./NumberField";
import {
  BuildingTypes,
  BuildingTypesToLabels,
  EnergyMeterEfficiencyModel,
  FirstTempZoneLabels,
  LabelToTempZone,
  SecondTempZoneLabels,
} from "../../interfaces";
import { produce } from "immer";
import InfoTooltip from "../InfoTooltip";
import StepDropDown from "./StepDropDown";
import YearlyNumbers from "./YearlyNumbers";

interface EnergyMeterFormProps {
  data: EnergyMeterEfficiencyModel;
  setData: (data: EnergyMeterEfficiencyModel) => void;
  dropCalculation: () => void;
  onCalculation: () => void;
}

const EnergyMeterForm: React.FC<EnergyMeterFormProps> = ({
  data,
  setData,
  dropCalculation,
  onCalculation,
}) => {
  const [confirmation, setConfirmation] = React.useState(false);

  return (
    <Container sx={{ mb: 25 }}>
      <Container sx={{ ml: 42 }}>
        <Box sx={{ ml: -1 }}>
          <Avatar sx={{ mt: 5, bgcolor: "primary.light", left: 180 }}>
            <MapsHomeWorkRounded />
          </Avatar>
          <Typography mt={2} ml={10} variant="h5">
            Характеристики будівлі
          </Typography>
        </Box>
        <Grid
          container
          width={"100%"}
          spacing={5}
          mt={2}
          sx={{ flex: "auto", maxWidth: "200px" }}
          textAlign={"center"}
        >
          <Grid item>
            <StepDropDown
              setData={(val) =>
                setData({
                  ...data,
                  building: val.target.value as BuildingTypes,
                })
              }
              label={"Тип будівлі"}
              value={data.building}
              menuItems={[
                {
                  value: BuildingTypes.Private,
                  label: BuildingTypesToLabels.get(BuildingTypes.Private) ?? "",
                },
                {
                  value: BuildingTypes.Common,
                  label: BuildingTypesToLabels.get(BuildingTypes.Common) ?? "",
                },
                {
                  value: BuildingTypes.Hotel,
                  label: BuildingTypesToLabels.get(BuildingTypes.Hotel) ?? "",
                },
                {
                  value: BuildingTypes.Educational,
                  label:
                    BuildingTypesToLabels.get(BuildingTypes.Educational) ?? "",
                },
                {
                  value: BuildingTypes.Preschool,
                  label:
                    BuildingTypesToLabels.get(BuildingTypes.Preschool) ?? "",
                },
                {
                  value: BuildingTypes.Healthcare,
                  label:
                    BuildingTypesToLabels.get(BuildingTypes.Healthcare) ?? "",
                },
                {
                  value: BuildingTypes.Trading,
                  label: BuildingTypesToLabels.get(BuildingTypes.Trading) ?? "",
                },
              ]}
            />
            <StepDropDown
              setData={(val) => {
                setData({
                  ...data,
                  tempZone: LabelToTempZone(val.target.value as string),
                  tempZoneLabel: val.target.value as string,
                });
              }}
              label={"Розташування будівлі"}
              value={data.tempZoneLabel}
              menuItems={[...FirstTempZoneLabels, ...SecondTempZoneLabels]
                .sort((a, b) => a.localeCompare(b, "ua"))
                .map((val) => ({ label: val, value: val }))}
            />

            <NumberField
              title={"Кількість поверхів"}
              min={1}
              max={50}
              value={data.stories}
              setData={(val: number) =>
                setData(
                  produce(data, (draft: EnergyMeterEfficiencyModel) => {
                    draft.stories = val;
                  })
                )
              }
            />

            <NumberField
              title={
                "Значення питомого енергоспоживання при опаленні та охолодженні"
              }
              min={1}
              max={100000}
              value={data.consumption}
              setData={(val) =>
                setData(
                  produce(data, (draft: EnergyMeterEfficiencyModel) => {
                    draft.consumption = val;
                  })
                )
              }
              measuringUnits="кВтхГод/м²"
              tooltip={
                <InfoTooltip
                  text={
                    "Визначається кількістю енергії, яка витрачається на забезпечення комфортної температури всередині будівлі."
                  }
                />
              }
            />

            <YearlyNumbers
              label={"Дані лічильника опалення щомісячно"}
              values={data.heatingConsumptionMonths}
              onUpdateValues={(values) =>
                setData(
                  produce(data, (draft: EnergyMeterEfficiencyModel) => {
                    draft.heatingConsumptionMonths = values;
                  })
                )
              }
              minValue={0}
              maxValue={1000}
              defaultValue={0}
              measuringUnits="Гкал"
            />

            <NumberField
              title={"Тариф на опалення, грн/ГКал"}
              min={1}
              max={10000}
              value={data.price}
              setData={(val: number) => setData({ ...data, price: val })}
            />
          </Grid>
        </Grid>

        {confirmation && (
          <Confirmation
            title={"Скинути все?"}
            declineContent={"Ні"}
            confirmContent={"Так"}
            onDecline={() => setConfirmation(false)}
            onConfirm={() => {
              setConfirmation(false);
              dropCalculation();
            }}
          />
        )}
      </Container>

      <div
        style={{
          width: "100%",
          height: "160px",
          backgroundColor: "#E0E0E0",
          justifyContent: "center",
          position: "fixed",
          left: 0,
          bottom: 0,
          zIndex: 2,
          display: "flex",
          flexDirection: "column",
          rowGap: "20px",
          alignItems: "center",
          padding: 2,
          boxShadow: "5px 5px 10px rgba(0, 0, 0, 0.5)",
        }}
      >
        <div>
          <Button
            onClick={() => setConfirmation(true)}
            sx={{ mr: 1 }}
            variant="contained"
          >
            Скинути
          </Button>

          <Button onClick={onCalculation} variant="contained">
            Розрахувати
          </Button>
        </div>

        <Box
          sx={{
            display: "flex",
            flexDirection: "row",
            pt: 2,
            position: "sticky",
          }}
        ></Box>
      </div>
    </Container>
  );
};

export default EnergyMeterForm;
