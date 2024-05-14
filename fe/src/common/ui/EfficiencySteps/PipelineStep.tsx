import { WaterDrop } from "@mui/icons-material";
import {
  Avatar,
  Container,
  CssBaseline,
  Grid,
  SelectChangeEvent,
  Typography,
} from "@mui/material";
import {
  CoolingMachineTypes,
  CoolingSystemTypes,
  HidraulicSystemTypes,
  HidraulicSystemDescriptions,
  PeriodicHeatingModes,
  PipelineTypes,
  PipelineSections,
  InsulatedOpenPipelines,
  EnergyEfficiencyInputModel,
  PipelineSectionsToLabels,
  OuterWallsPipelines,
} from "../../interfaces";
import StepDropDown from "./StepDropDown";
import RangeSlider from "./NumberField";
import InfoTooltip from "../InfoTooltip";

interface PipelineStepProps {
  data: EnergyEfficiencyInputModel;
  setData: (data: EnergyEfficiencyInputModel) => void;
}

const PipelineStep: React.FC<PipelineStepProps> = (props) => {
  const { data, setData } = props;

  const getHidraulicSystemDescriptionOptions = (
    selectedSystemType: HidraulicSystemTypes
  ) => {
    return HidraulicSystemDescriptions.get(selectedSystemType);
  };

  const getPipelineSectionsDropDown = () => {
    return (
      <StepDropDown
        setData={(event: SelectChangeEvent<any>) => {
          setData({
            ...data,
            pipelineSections: event.target.value,
          });
        }}
        label={"Наявні секції трубопроводу"}
        isMultiple={true}
        renderValues={(selected) =>
          selected
            .map((element: number) =>
              PipelineSectionsToLabels.get(element.toString())
            )
            .join(", ")
        }
        value={data.pipelineSections}
        menuItems={[
          {
            label: "Lv",
            value: PipelineSections.Lv,
          },
          {
            label: "Ls",
            value: PipelineSections.Ls,
          },
          {
            label: "La",
            value: PipelineSections.La,
          },
        ]}
        tooltip={
          <InfoTooltip
            text={
              "Трубопороводи опалення зазвичай складаються із різних типів секцій, де Lv - довжина трубопроводу між теплогенератором та стояками; Ls - довжина вертикальних трубопроводів (стояків); La - з’єднувальні трубопроводи (вузли обв’язки)."
            }
          />
        }
      />
    );
  };

  const getOuterPipelinesDropDown = () => {
    return (
      <StepDropDown
        setData={(event: SelectChangeEvent<any>) => {
          setData({
            ...data,
            outerWallsPipeline: event.target.value,
          });
        }}
        label={"Тип  теелоізоляції стін"}
        value={data.outerWallsPipeline}
        menuItems={[
          {
            label: "Стіни не теплоізольовані",
            value: OuterWallsPipelines.WallsNotInsulated,
          },
          {
            label: "Стіни неізольовані з високим ступенем опору теплопередачі",
            value:
              OuterWallsPipelines.WallsNotInsulatedWithHeatTransferResistance,
          },
          {
            label: "Стіни теплоізольовані",
            value: OuterWallsPipelines.WallsWithOuterInsulation,
          },
        ]}
      />
    );
  };

  const getPipelineTypeDropDown = () => {
    return (
      <StepDropDown
        setData={(event: SelectChangeEvent<any>) =>
          setData({
            ...data,
            pipelineType: event.target.value as PipelineTypes,
          })
        }
        label={"Тип трубопроводу опалення"}
        value={data.pipelineType}
        menuItems={[
          {
            label: "Ізольований відкрито прокладентй трубопровід",
            value: PipelineTypes.InsulatedOpen,
            underContent: (
              <>
                <StepDropDown
                  setData={(event: SelectChangeEvent<any>) =>
                    setData({
                      ...data,
                      insulatedDate: event.target
                        .value as InsulatedOpenPipelines,
                    })
                  }
                  label={"Характеристика"}
                  value={data.insulatedDate}
                  menuItems={[
                    {
                      label: "Встановлено після 2014 року",
                      value: InsulatedOpenPipelines.After2014,
                    },
                    {
                      label: "Встановлено у 1980-1995 роках",
                      value: InsulatedOpenPipelines.From1980To1995,
                    },
                    {
                      label: "Встановлено до 1980 року",
                      value: InsulatedOpenPipelines.Before1980,
                    },
                  ]}
                />
                {getPipelineSectionsDropDown()}
              </>
            ),
          },
          {
            label: "Неізольований трубопровід",
            value: PipelineTypes.UnIinsulated,
            underContent: getPipelineSectionsDropDown(),
          },
          {
            label: "Трубопровід, прокладений у зовнішніх стінах",
            value: PipelineTypes.OuterWalls,
            underContent: getOuterPipelinesDropDown(),
          },
        ]}
      />
    );
  };

  return (
    <Container maxWidth="xs" sx={{ mb: 30 }}>
      <CssBaseline />

      <Avatar sx={{ mt: 5, left: 160, bgcolor: "primary.light" }}>
        <WaterDrop />
      </Avatar>

      <Typography mt={2} ml={3} variant="h5" width={400}>
        {"Охолодження та трубопровід"}
      </Typography>

      <Grid
        container
        width={1050}
        spacing={4}
        ml={-40}
        mt={2}
        sx={{ flex: "auto" }}
      >
        <Grid item>
          <StepDropDown
            setData={(event) =>
              setData({
                ...data,
                coolingMachineType: event.target.value as CoolingMachineTypes,
              })
            }
            label={"Тип охолоджувальної машини"}
            value={data.coolingMachineType}
            menuItems={[
              {
                label: "Компресорна холодильна машина / зовнішнє повітря",
                value: CoolingMachineTypes.CompressorAirBased,
              },
              {
                label:
                  "Компресорна холодильна машина / ґрунтовий теплообмін або використання ґрунтових вод",
                value: CoolingMachineTypes.CompressorSoilBased,
              },
              {
                label: "Абсорбційний охолоджувач / зовнішнє повітря",
                value: CoolingMachineTypes.Absorbal,
              },
              {
                label:
                  "Безпосереднє охолодження / ґрунтовий теплообмін або використання ґрунтових вод",
                value: CoolingMachineTypes.DirectCooling,
              },
            ]}
          />
          <StepDropDown
            setData={(event) =>
              setData({
                ...data,
                coolingSystemType: event.target.value as CoolingSystemTypes,
              })
            }
            label={"Тип системи охоложення"}
            value={data.coolingSystemType}
            menuItems={[
              {
                label: "Холодна вода 7/12",
                value: CoolingSystemTypes.ColdWater7To12,
              },
              {
                label: "Холодна вода 8/14",
                value: CoolingSystemTypes.ColdWater8To14,
              },
              {
                label: "Холодна вода 14/18",
                value: CoolingSystemTypes.ColdWater14To18,
              },
              {
                label: "Холодна вода 18/20",
                value: CoolingSystemTypes.ColdWater18To20,
              },
              {
                label: "Пряме випаровування",
                value: CoolingSystemTypes.DirectEvaporation,
              },
            ]}
          />
          <StepDropDown
            setData={(event) =>
              setData({
                ...data,
                hidraulicSystemType: event.target.value as HidraulicSystemTypes,
                hidraulicSystemDescription: HidraulicSystemDescriptions.get(
                  event.target.value as HidraulicSystemTypes
                )![0].value,
              })
            }
            label={"Тип гідравлічної системи"}
            value={data.hidraulicSystemType}
            menuItems={[
              {
                label: "Однотрубна (постійний гідравлічний режим)",
                value: HidraulicSystemTypes.OnePipedConstantMode,
              },
              {
                label: "Однотрубна (змінний гідравлічний режим)",
                value: HidraulicSystemTypes.OnePipedVariabletMode,
              },
              {
                label: "Двотрубна",
                value: HidraulicSystemTypes.TwoPiped,
              },
            ]}
            tooltip={
              <InfoTooltip
                text={
                  "Мережа трубопроводів, насосів, резервуарів та інших пристроїв, яка використовується для постачання та розподілу рідини, зазвичай води, по всій будівлі"
                }
              />
            }
          />
        </Grid>
        <Grid item>
          <StepDropDown
            setData={(val) =>
              setData({
                ...data,
                hidraulicSystemDescription: val.target.value,
              })
            }
            label={"Налагодженість гідравлічної системи"}
            value={data.hidraulicSystemDescription}
            menuItems={
              getHidraulicSystemDescriptionOptions(data.hidraulicSystemType) ??
              []
            }
            tooltip={
              <InfoTooltip
                text={
                  "Ступінь оптимізації роботи гідравлічної системи для досягнення оптимальної продуктивності, ефективності та безпеки"
                }
              />
            }
          />
          <StepDropDown
            setData={(val) =>
              setData({
                ...data,
                periodicHeatingType: val.target.value,
              })
            }
            label={"Тип теплового режиму"}
            value={data.periodicHeatingType}
            menuItems={[
              {
                value: PeriodicHeatingModes.Constant,
                label: "Постійний тепловий режим",
              },
              {
                value: PeriodicHeatingModes.PeriodicWithoutIntegratedFeedback,
                label:
                  "Періодичний тепловий режим з регулюванням без інтегрованого зворотного зв’язку",
              },
              {
                value: PeriodicHeatingModes.PeriodicWithIntegratedFeedback,
                label:
                  "Періодичний тепловий режим з регулюванням, що має інтегрований зворотний зв’язок",
              },
            ]}
            tooltip={
              <InfoTooltip
                text={
                  "Визначається температурою повітря, рівнем вологості, розподілом тепла в будівлі"
                }
              />
            }
          />
          <RangeSlider
            title={"Довжина трубопроводу опалення"}
            min={1}
            max={200}
            value={data.pipelineLength}
            setData={(val: number) => setData({ ...data, pipelineLength: val })}
            measuringUnits="м"
          />
        </Grid>
        <Grid item>{getPipelineTypeDropDown()}</Grid>
      </Grid>
    </Container>
  );
};

export default PipelineStep;
