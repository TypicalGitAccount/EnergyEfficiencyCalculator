namespace EnergyEfficiencyBE
{
    public static class Constants
    {
        public const string SuperAdminName = "SuperAdmin";
        public const string SuperAdminEmail = "admin@mail.com";
        public const string SuperAdminPassword = "Admin1!";
        public const ulong AccessTokenLifetimeInMinutes = 60 * 24 * 3;
        public const ulong RefreshTokenLifetimeInMinutes = 60 * 6;

        public struct EnergyEfficiencyClass
        {
            public const string a = "a";
            public const string b = "b";
            public const string c = "c";
            public const string d = "d";
            public const string e = "e";
            public const string f = "f";
            public const string g = "g";
        };

        public enum BuildingType
        {
            Any,
            Private,
            Common,
            Hotel,
            Educational,
            Preschool,
            Healthcare,
            Trading
        };

        public enum TemperatureZone
        {
            First,
            Second
        }

        public struct CoolingMachineTypes
        {
            public const string CompressorAirBased = "CompressorAirBased";
            public const string CompressorSoilBaased = "CompressorSoilBaased";
            public const string Absorbal = "Absorbal";
            public const string DirectCooling = "DirectCooling";
        }

        public struct CoolingSystemTypes
        {
            public const int FactorsAmount = 3;
            public const string ColdWater7To12 = "ColdWater7To12";
            public const string ColdWater8To14 = "ColdWater8To14";
            public const string ColdWater14To18 = "ColdWater14To18";
            public const string ColdWate16To18 = "ColdWate16To18";
            public const string ColdWater18To20 = "ColdWater18To20";
            public const string DirectEvaporation = "DirectEvaporation";
        }

        public static readonly IReadOnlyDictionary<string, decimal> AutoRegulationEfficiency =
            new Dictionary<string, decimal>
            {
                { EnergyEfficiencyClass.a, 0.99m },
                { EnergyEfficiencyClass.b, 0.93m },
                { EnergyEfficiencyClass.c, 0.88m },
                { EnergyEfficiencyClass.d, 0.82m }
            };

        public enum PipelineTypes
        {
            InsulatedOpen,
            UnIinsulated,
            OuterWalls
        }

        public enum InsulatedOpenPipelines
        {
            After2014,
            From1980To1995,
            Before1980,
            None
        }

        public enum OuterWallsPipelines
        {
            WallsNotInsulated,
            WallsWithOuterInsulation,
            WallsNotInsulatedWithHeatTransferResistance,
            None
        }

        public enum PipelineSections
        {
            Lv,
            Ls,
            La,
            None
        }

        public enum BuildingAreaConstraints
        {
            AreaLessThan200,
            AreaFro200To500,
            AreaFrom500,
            None
        }

        public static class PeriodicHeatingModes
        {
            public const string Constant = "Constant";
            public const string PeriodicWithoutIntegratedFeedback = "PeriodicWithoutIntegratedFeedback";
            public const string PeriodicWithIntegratedFeedback = "PeriodicWithIntegratedFeedback";
        }

        public static readonly IReadOnlyDictionary<string, decimal> PeriodicHeatingModeFactor =
            new Dictionary<string, decimal>
            {
                { PeriodicHeatingModes.Constant, 1m },
                { PeriodicHeatingModes.PeriodicWithoutIntegratedFeedback, 0.98m },
                { PeriodicHeatingModes.PeriodicWithIntegratedFeedback, 0.97m }
            };

        public static class HidraulicSystemTypes
        {
            public static class TwoPiped
            {
                public const string Value = "TwoPiped";

                public static class SystemDescriptions
                {
                    public static string NotConfigured = "NotConfigured";
                    public static string ConfiguredWithMoreThan8Heaters = "ConfiguredWithMoreThan8Heaters";
                    public static string ConfiguredWith8OrLessHeaters = "ConfiguredWith8OrLessHeaters";
                    public static string ConfiguredWithAutoPressureRegulation = "ConfiguredWithAutoPressureRegulation";
                }
            }
            public static class OnePipedConstantMode
            {
                public const string Value = "OnePipedConstantMode";

                public static class SystemDescriptions
                {
                    public static string NotConfiguredNoBalancingArmoring = "NotConfiguredNoBalancingArmoring";
                    public static string ConfiguredWithManualArmoring = "ConfiguredWithManualArmoring";
                    public static string ConfiguredWitAutoRegulators = "ConfiguredWitAutoRegulators";
                }
            }
            public static class OnePipedVariabletMode
            {
                public const string Value = "OnePipedVariabletMode";

                public static class SystemDescriptions
                {
                    public static string NotConfigured = "NotConfigured";
                    public static string Configured = "Configured";
                }
            }
        }

        public const decimal RadiantHeatingSystemTypeFactor = 0.85m;

        public enum TemperatureComponents
        {
            TemperatureRegulation,
            TemperatureDifference,
            OuterEnclosureHeatLoss
        }

        public enum TemperatureRegulationOptions
        {
            None,
            Absent,
            WhileAverageBuildingTemp,
            PRegulation2K,
            PRegulation1K,
            PIRegulation,
            PiRegulationOptimised
        }

        public enum TemperatureDifferenceOptions
        {
            None,
            K60,
            K42,
            K30
        }

        public enum OuterEnclosureHeatLoss
        {
            None,
            HeaterNearInnerWall,
            HeaterNearOuterWallNoRadiationalProtection,
            HeaterNearOuterWallWithRadiationalProtection,
            HeaterNearRegularOuterWall
        }


        public enum SeasonalHeatGenerationDevices
        {
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
            CentralisedHotWaterDistributionRestraintITPAccumulation
        }


        public enum HeaterFactors
        {
            Any,
            Before1994,
            From1994To2008,
            After2008
        }

        public static readonly IReadOnlyDictionary<HeaterFactors, string> SeasonalHeatGenerationFactorFieldNames =
            new Dictionary<HeaterFactors, string>
            {
                { HeaterFactors.Any, "AnyFactor" },
                { HeaterFactors.Before1994, "Before1994Factor" },
                { HeaterFactors.From1994To2008, "From1994To2008Factor" },
                { HeaterFactors.After2008, "From2008Factor" }
            };
    }
}
