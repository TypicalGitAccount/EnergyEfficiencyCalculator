import { CalculationMode } from "../pages/Efficiency";
import { DropDownItem } from "./ui/EfficiencySteps/StepDropDown";

export type ApiResponse<T> =
  | { data: T; status: number }
  | { status: number; error: any };

export interface AuthUser {
  id: string;
  name: string;
  email: string;
  role: string[];
}

export interface Jwts {
  accessToken: string;
  refreshToken: string;
}

export interface User {
  id: string;
  name: string;
  email: string;
  phone: string;
  telegram: string;
}

export interface UserUpdateDto {
  id: string;
  name: string;
  email: string;
  phone: string;
  telegram: string;
}

export interface AdviceDto {
  id: string;
  title: string;
  recommendationText: string;
  minPrice: number;
  maxPrice: number;
  buildingType: BuildingTypes;
}

export interface AdviceCriteriaDto {
  minPrice: number;
  maxPrice: number;
  buildingType: BuildingTypes;
}

export enum BuildingTypes {
  Any,
  Private,
  Common,
  Hotel,
  Educational,
  Preschool,
  Healthcare,
  Trading,
}

export const BuildingTypesToLabels = new Map<BuildingTypes, string>([
  [BuildingTypes.Any, "Будь-яка"],
  [BuildingTypes.Private, "Приватний будинок"],
  [BuildingTypes.Common, "Багатоповерхівка"],
  [BuildingTypes.Hotel, "Готель"],
  [BuildingTypes.Educational, "Заклад освіти"],
  [BuildingTypes.Preschool, "Заклад дошкільної освіти"],
  [BuildingTypes.Healthcare, "Заклад охорони здоров'я"],
  [BuildingTypes.Trading, "Торгівельна"],
]);

export enum TempZones {
  First,
  Second,
}

export const LabelToTempZone = (label: string) => {
  return FirstTempZoneLabels.includes(label)
    ? TempZones.First
    : TempZones.Second;
};

export const FirstTempZoneLabels = [
  "Вінницька обл",
  "Волинська обл",
  "Дніпропетровська обл",
  "Донецька обл",
  "Житомирська обл",
  "Івано-Франківська обл",
  "Київська обл",
  "Кіровоградська обл",
  "Луганська обл",
  "Полтавська обл",
  "Рівненська обл",
  "Сумська обл",
  "Тернопільська обл",
  "Харківська обл",
  "Хмельницька обл",
  "Черкаська обл",
  "Чернівецька обл",
  "Чернігівська обл",
];

export const SecondTempZoneLabels = [
  "АР Крим",
  "Запорізька обл",
  "Закарпатська обл",
  "Миколаївська обл",
  "Одеська обл",
  "Херсонська обл",
];

export enum RegulationSystemEfficiencyClass {
  a = "a",
  b = "b",
  c = "c",
  d = "d",
}

export enum EfficiencyClass {
  a = "a",
  b = "b",
  c = "c",
  d = "d",
  e = "e",
  f = "f",
  g = "g",
}

export const EfficiencyClassToDesc = new Map<EfficiencyClass, string>([
  [EfficiencyClass.a, "Найвищий результат!"],
  [EfficiencyClass.b, "Чудовий результат"],
  [EfficiencyClass.c, "Хороший результат"],
  [EfficiencyClass.d, "Посередній рівень енергоефективності"],
  [EfficiencyClass.e, "Посередній рівень енергоефективності"],
  [EfficiencyClass.f, "Слабкий результат"],
  [EfficiencyClass.g, "Найнижчий рівень енергоефективності"],
]);

export enum CoolingMachineTypes {
  CompressorAirBased = "CompressorAirBased",
  CompressorSoilBased = "CompressorSoilBaased",
  Absorbal = "Absorbal",
  DirectCooling = "DirectCooling",
}

export enum CoolingSystemTypes {
  ColdWater7To12 = "ColdWater7To12",
  ColdWater8To14 = "ColdWater8To14",
  ColdWater14To18 = "ColdWater14To18",
  ColdWate16To18 = "ColdWate16To18",
  ColdWater18To20 = "ColdWater18To20",
  DirectEvaporation = "DirectEvaporation",
}

export enum HidraulicSystemTypes {
  TwoPiped = "TwoPiped",
  OnePipedConstantMode = "OnePipedConstantMode",
  OnePipedVariabletMode = "OnePipedVariabletMode",
}

export const HidraulicSystemDescriptions = new Map<
  HidraulicSystemTypes,
  DropDownItem[]
>([
  [
    HidraulicSystemTypes.TwoPiped,
    [
      {
        value: "NotConfigured",
        label:
          "Система не налагоджена. Відсутні балансувальні клапани на стояках (горизонтальних вітках) системи",
      },
      {
        value: "ConfiguredWithMoreThan8Heaters",
        label:
          "Наявні автоматичні регулятори перепаду тиску на стояках (вітках) з більше ніж вісьмома опалювальними приладами \
            або наявне тільки статичне налагодження системи (ручні балансувальні клапани)",
      },
      {
        value: "ConfiguredWith8OrLessHeaters",
        label:
          "Наявні автоматичні регулятори перепаду тиску на стояках (вітках) з вісьмома та менше опалювальними приладами",
      },
      {
        value: "ConfiguredWithAutoPressureRegulation",
        label:
          "Наявне автоматичне регулювання перепаду тиску в терморегуляторах або \
            електронних регуляторах витрати теплоносія на опалювальних приладах (автоматичних регуляторах температури повітря у приміщенні)",
      },
    ],
  ],
  [
    HidraulicSystemTypes.OnePipedConstantMode,
    [
      {
        value: "NotConfiguredNoBalancingArmoring",
        label:
          "Відсутня балансувальна арматура на стояках (горизонтальних вітках) системи",
      },
      {
        value: "ConfiguredWithManualArmoring",
        label:
          "Наявна ручна балансувальна арматура на стояках (горизонтальних вітках)",
      },
      {
        value: "ConfiguredWitAutoRegulators",
        label:
          "Наявні автоматичні регулятори (стабілізатори) витрати на стояках (горизонтальних вітках)",
      },
    ],
  ],
  [
    HidraulicSystemTypes.OnePipedVariabletMode,
    [
      {
        value: "NotConfigured",
        label:
          "Наявні автоматичні регулятори (обмежувачі) витрати зі \
            стабілізацією температури теплоносія на виході зі стояка (горизонтальної вітки)",
      },
      {
        value: "Configured",
        label:
          "Наявні автоматичні регулятори (обмежувачі) витрати з регулюванням \
            температури теплоносія на виході зі стояка (горизонтальної вітки) за температурним графіком",
      },
    ],
  ],
]);

export enum PeriodicHeatingModes {
  Constant = "Constant",
  PeriodicWithoutIntegratedFeedback = "PeriodicWithoutIntegratedFeedback",
  PeriodicWithIntegratedFeedback = "PeriodicWithIntegratedFeedback",
}

export enum PipelineTypes {
  InsulatedOpen,
  UnIinsulated,
  OuterWalls,
}

export enum InsulatedOpenPipelines {
  After2014,
  From1980To1995,
  Before1980,
  None,
}

export enum OuterWallsPipelines {
  WallsNotInsulated,
  WallsWithOuterInsulation,
  WallsNotInsulatedWithHeatTransferResistance,
  None,
}

export enum PipelineSections {
  Lv,
  Ls,
  La,
  None,
}

export const PipelineSectionsToLabels = new Map<string, string>([
  [PipelineSections.None.toString(), "None"],
  [PipelineSections.Lv.toString(), "Lv"],
  [PipelineSections.Ls.toString(), "Ls"],
  [PipelineSections.La.toString(), "La"],
]);

export enum HeaterFactors {
  Any,
  Before1994,
  From1994To2008,
  After2008,
}

export enum SeasonalHeatGenerationDevices {
  CoalHeaterManual,
  CeramicFurnance,
  GasConvector,
  GasHeaterWithSwich,
  LiquidFuelModularBurner,
  LiquidFuelLowTemperatur,
  HeavyMazutSteamHeater,
  LPGHeaterCompressor55C,
  LPGHeaterCompressor35C,
  ElectricTankless,
  ElectricDirectHeating,
  BiomassFurnance,
  WoodBiomassHeaterGasified,
  CentralisedConstantTemp,
  CentralisedHotWaterDistributionRestraintITPAccumulation,
}

export const SeasonalOptionsWithNoDating = [
  SeasonalHeatGenerationDevices.LiquidFuelLowTemperatur,
  SeasonalHeatGenerationDevices.LiquidFuelModularBurner,
  SeasonalHeatGenerationDevices.LPGHeaterCompressor35C,
  SeasonalHeatGenerationDevices.LPGHeaterCompressor55C,
  SeasonalHeatGenerationDevices.ElectricDirectHeating,
  SeasonalHeatGenerationDevices.ElectricTankless,
];

export const SeasonalHeaterOptions = [
  {
    label: "Вугільніий котел з ручним керуванням",
    value: SeasonalHeatGenerationDevices.CoalHeaterManual,
  },
  {
    label: "Кахельна піч",
    value: SeasonalHeatGenerationDevices.CeramicFurnance,
  },
  {
    label: "Газовий кімнатний конвектор",
    value: SeasonalHeatGenerationDevices.GasConvector,
  },
  {
    label:
      "Природний і скраплений вуглеводневий газ - Котел з автоматичною або ручною функцією увімкнення/вимкнення",
    value: SeasonalHeatGenerationDevices.GasHeaterWithSwich,
  },
  {
    label:
      "Рідке паливо та легкий сорт мазуту - Котел з модульованим пальником",
    value: SeasonalHeatGenerationDevices.LiquidFuelModularBurner,
  },
  {
    label: "Рідке паливо та легкий сорт мазуту - Низькотемпературний котел",
    value: SeasonalHeatGenerationDevices.LiquidFuelLowTemperatur,
  },
  {
    label: "В’язкий сорт мазуту - Паровий котел",
    value: SeasonalHeatGenerationDevices.HeavyMazutSteamHeater,
  },
  {
    label:
      "Тепловий насос типу гліколь/вода, компресор з газотурбінним приводом: 55/45 °C",
    value: SeasonalHeatGenerationDevices.LPGHeaterCompressor55C,
  },
  {
    label:
      "Тепловий насос типу гліколь/вода, компресор з газотурбінним приводом: 35/28 °C",
    value: SeasonalHeatGenerationDevices.LPGHeaterCompressor35C,
  },
  {
    label: "Електричний проточний водонагрівач",
    value: SeasonalHeatGenerationDevices.ElectricTankless,
  },
  {
    label:
      "Електричні прилади прямого нагрівання: конвектори, поверхневе опалення, променеве опалення, нагрівальний підлоговий кабель",
    value: SeasonalHeatGenerationDevices.ElectricDirectHeating,
  },
  {
    label: "Біомаса - Піч/камін з ручним подаванням",
    value: SeasonalHeatGenerationDevices.BiomassFurnance,
  },
  {
    label:
      "Котли на біомасі (солома) автоматичні потужністю: від 100 кВт до 600 кВт",
    value: SeasonalHeatGenerationDevices.CoalHeaterManual,
  },
  {
    label: "Котел на біомасі газифікований",
    value: SeasonalHeatGenerationDevices.WoodBiomassHeaterGasified,
  },
  {
    label:
      "Централізоване опалення - Постійна температура теплоносія без коригування в ІТП",
    value: SeasonalHeatGenerationDevices.CentralisedConstantTemp,
  },
  {
    label:
      "Централізоване опалення - Система гарячого водопостачання зі швидкісним теплообмінником, акумулюванням в ІТП та регулюванням теплового потоку за розкладом, з обмеженням максимальної витрати автоматичними засобами",
    value:
      SeasonalHeatGenerationDevices.CentralisedHotWaterDistributionRestraintITPAccumulation,
  },
];

export enum TemperatureComponents {
  TemperatureRegulation,
  TemperatureDifference,
  OuterEnclosureHeatLoss,
}

export enum TemperatureRegulationOptions {
  None,
  Absent,
  WhileAverageBuildingTemp,
  PRegulation2K,
  PRegulation1K,
  PIRegulation,
  PiRegulationOptimised,
}

export enum TemperatureDifferenceOptions {
  None,
  K60,
  K42,
  K30,
}

export enum OuterEnclosureHeatLoss {
  None,
  HeaterNearInnerWall,
  HeaterNearOuterWallNoRadiationalProtection,
  HeaterNearOuterWallWithRadiationalProtection,
  HeaterNearRegularOuterWall,
}

export interface EnergyEfficiencyInputModel {
  building: BuildingTypes;
  tempZone: number;
  stories: number;
  totalInnerArea: number;
  totalHeatedArea: number;
  totalInnerHeight: number;
  regulationSystemEfficiencyClass: RegulationSystemEfficiencyClass;

  heaterFactorFieldName: HeaterFactors;
  seasonalHeaterType: SeasonalHeatGenerationDevices;
  temperatureComponentType: TemperatureComponents;
  regulationOptions: TemperatureRegulationOptions;
  temperaturDifference: TemperatureDifferenceOptions;
  heatLoss: OuterEnclosureHeatLoss;
  isRadiantHeatingSystem: boolean;
  avgYearlyHeatCarrierTemp: number[];
  avgYearlyEnvironmentTemp: number[];
  avgYearlyHeatingHours: number[];
  heatingConsumptionMonths: number[];
  electicityGenerationEfficiency: number;
  heatGenerationEfficiency: number;
  heatingUsageFactor: number;
  yearlyHeatingSubsystemExitEnergy: number;
  price: number;

  coolingMachineType: CoolingMachineTypes;
  coolingSystemType: CoolingSystemTypes;
  hidraulicSystemType: HidraulicSystemTypes;
  hidraulicSystemDescription: string;
  periodicHeatingType: PeriodicHeatingModes;
  pipelineLength: number;
  pipelineType: PipelineTypes;
  pipelineSections: PipelineSections[];
  insulatedDate: InsulatedOpenPipelines;
  outerWallsPipeline: OuterWallsPipelines;
}

export interface EnergyMeterEfficiencyModel {
  building: BuildingTypes;
  tempZone: number;
  tempZoneLabel: string;
  stories: number;
  totalHeatedArea: number;
  heatingConsumptionMonths: number[];
  price: number;
  consumption: number;
}

export interface PaymentsModel {
  heatingConsumptionMonths: number[];
  price: number;
}

export interface EfficiencyResultsModel {
  calculationMode: CalculationMode;
  class: EfficiencyClass;
  heatingPaymentsMonths: number[];
  building: BuildingTypes;
}

export interface EfficiencyMeterInputModel {
  efficiencyValue: number;
  stories: number;
  tempZone: TempZones;
  building: BuildingTypes;
}

export const getDefaultEfficiencyModel = () => {
  return {
    building: BuildingTypes.Private,
    tempZone: TempZones.First,
    stories: 1,
    totalInnerArea: 1,
    totalHeatedArea: 1,
    totalInnerHeight: 1,
    regulationSystemEfficiencyClass: RegulationSystemEfficiencyClass.a,
    heatingConsumptionMonths: Array.from({ length: 12 }, () => 0),

    heaterFactorFieldName: HeaterFactors.After2008,
    seasonalHeaterType: SeasonalHeatGenerationDevices.CoalHeaterManual,
    temperatureComponentType: TemperatureComponents.TemperatureRegulation,
    regulationOptions: TemperatureRegulationOptions.Absent,
    temperaturDifference: TemperatureDifferenceOptions.None,
    heatLoss: OuterEnclosureHeatLoss.None,
    isRadiantHeatingSystem: false,
    avgYearlyHeatCarrierTemp: [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    avgYearlyEnvironmentTemp: [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    avgYearlyHeatingHours: [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    electicityGenerationEfficiency: 1,
    heatGenerationEfficiency: 1,
    heatingUsageFactor: 1,
    yearlyHeatingSubsystemExitEnergy: 500,
    price: 1,

    coolingMachineType: CoolingMachineTypes.DirectCooling,
    coolingSystemType: CoolingSystemTypes.DirectEvaporation,
    hidraulicSystemType: HidraulicSystemTypes.TwoPiped,
    hidraulicSystemDescription: HidraulicSystemDescriptions.get(
      HidraulicSystemTypes.TwoPiped
    )![0].value,
    periodicHeatingType: PeriodicHeatingModes.Constant,
    pipelineLength: 1,
    pipelineType: PipelineTypes.UnIinsulated,
    insulatedDate: InsulatedOpenPipelines.After2014,
    outerWallsPipeline: OuterWallsPipelines.WallsNotInsulated,
    pipelineSections: [PipelineSections.Lv],
  };
};

export function getDefaultEnergyMeterModel(): EnergyMeterEfficiencyModel {
  return {
    building: BuildingTypes.Private,
    stories: 1,
    tempZone: TempZones.First,
    tempZoneLabel: FirstTempZoneLabels.at(0)!,
    totalHeatedArea: 1,
    heatingConsumptionMonths: Array.from({ length: 12 }, () => 0),
    price: 1,
    consumption: 1,
  };
}

export const monthLabels = [
  "Січень",
  "Лютий",
  "Березень",
  "Квітень",
  "Травень",
  "Червень",
  "Липень",
  "Серпень",
  "Вересень",
  "Жовтень",
  "Листопад",
  "Грудень",
];
