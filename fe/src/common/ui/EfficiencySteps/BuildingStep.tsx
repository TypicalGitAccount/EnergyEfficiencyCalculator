import { MapsHomeWorkRounded } from "@mui/icons-material";
import { Avatar, Grid, Typography } from "@mui/material";
import {
  BuildingTypes,
  BuildingTypesToLabels,
  EnergyEfficiencyInputModel,
  FirstTempZoneLabels,
  LabelToTempZone,
  RegulationSystemEfficiencyClass,
  SecondTempZoneLabels,
  TempZones,
} from "../../interfaces";
import RangeSlider from "./NumberField";
import StepDropDown from "./StepDropDown";
import InfoTooltip from "../InfoTooltip";
import { useState } from "react";

interface BuildingStepProps {
  data: EnergyEfficiencyInputModel;
  setData: (data: EnergyEfficiencyInputModel) => void;
}

const BuildingStep: React.FC<BuildingStepProps> = (props) => {
  const { data, setData } = props;
  const [tempZoneLabel, setTempZoneLabel] = useState(FirstTempZoneLabels[0]);

  return (
    <>
      <Avatar sx={{ mt: 5, bgcolor: "primary.light", left: 180 }}>
        <MapsHomeWorkRounded />
      </Avatar>
      <Typography mt={2} ml={10} variant="h5">
        Характеристики будівлі
      </Typography>

      <Grid
        container
        width={"155%"}
        spacing={5}
        mt={2}
        ml={-12}
        sx={{ flex: "auto" }}
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
                label: BuildingTypesToLabels.get(BuildingTypes.Preschool) ?? "",
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
              setTempZoneLabel(val.target.value as string);
              setData({
                ...data,
                tempZone: LabelToTempZone(val.target.value as string),
              });
            }}
            label={"Розташування будівлі"}
            value={tempZoneLabel}
            menuItems={[...FirstTempZoneLabels, ...SecondTempZoneLabels]
              .sort((a, b) => a.localeCompare(b, "ua"))
              .map((val) => ({ label: val, value: val }))}
          />
          <RangeSlider
            title={"Кількість поверхів"}
            min={1}
            max={50}
            value={data.stories}
            setData={(val: number) => setData({ ...data, stories: val })}
          />
        </Grid>
        <Grid item>
          <RangeSlider
            title={"Загальна площа"}
            min={1}
            max={3500}
            value={data.totalInnerArea}
            setData={(val: number) => setData({ ...data, totalInnerArea: val })}
            measuringUnits="м²"
          />
          <RangeSlider
            title={"Опалювана площа"}
            min={1}
            max={data.totalInnerArea}
            value={data.totalHeatedArea}
            setData={(val: number) =>
              setData({ ...data, totalHeatedArea: val })
            }
            measuringUnits="м²"
            tooltip={
              <InfoTooltip
                text={
                  "Площа поверхів будівлі, яка вимірюється в межах внутрішніх поверхонь зовнішніх стін, включаючи перегородки й внутрішні стіни."
                }
              />
            }
          />
          <RangeSlider
            title={"Загальна внутрішня висота"}
            min={1}
            max={200}
            value={data.totalInnerHeight}
            setData={(val: number) =>
              setData({ ...data, totalInnerHeight: val })
            }
            measuringUnits="м"
            tooltip={
              <InfoTooltip
                text={
                  "Вимірюється від поверхні підлоги першого поверху до поверхні стелі останнього поверху."
                }
              />
            }
          />
        </Grid>

        <div style={{ marginLeft: "50px" }}>
          <StepDropDown
            setData={(val) =>
              setData({
                ...data,
                regulationSystemEfficiencyClass: val.target
                  .value as RegulationSystemEfficiencyClass,
              })
            }
            label={
              "Клас енергоефективності системи управління/регулювання будівлі"
            }
            value={data.regulationSystemEfficiencyClass}
            menuItems={[
              { value: RegulationSystemEfficiencyClass.a, label: "A" },
              { value: RegulationSystemEfficiencyClass.b, label: "B" },
              { value: RegulationSystemEfficiencyClass.c, label: "C" },
              { value: RegulationSystemEfficiencyClass.d, label: "D" },
            ]}
            tooltip={
              <InfoTooltip
                text={
                  "Оцінений рівень автоматизації і технічного управління будівлею"
                }
              />
            }
          />
        </div>
      </Grid>
    </>
  );
};

export default BuildingStep;
