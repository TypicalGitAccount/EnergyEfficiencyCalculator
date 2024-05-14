import {
  Box,
  Button,
  Card,
  SelectChangeEvent,
  Typography,
} from "@mui/material";
import React from "react";
import StepDropDown from "./StepDropDown";
import { CalculationMode } from "../../../pages/Efficiency";
import { Link } from "react-router-dom";

interface StartCalculationProps {
  calculationMode: CalculationMode;
  setCalculationMode: (mode: CalculationMode) => void;
  handleStart: () => void;
}

const StartCalculation: React.FC<StartCalculationProps> = ({
  calculationMode,
  setCalculationMode,
  handleStart,
}) => {
  return (
    <>
      <Card
        variant="outlined"
        component={Button}
        sx={{
          p: 3,
          height: "fit-content",
          width: "100%",
          background: "none",
          backgroundColor: "action.selected",
          marginTop: "200px",
        }}
      >
        <Box
          sx={{
            width: "100%",
            display: "flex",
            textAlign: "left",
            flexDirection: { xs: "column", md: "row" },
            alignItems: { md: "center" },
            gap: 2.5,
          }}
        >
          <Box
            sx={{
              color: (theme) => {
                return "primary.main";
              },
            }}
          >
            <Box
              component="img"
              sx={{
                height: 350,
                width: 500,
              }}
              alt="Eneregy efficiency scale"
              src={`${process.env.PUBLIC_URL}/scale.png`}
            />
          </Box>

          <Box sx={{ textTransform: "none" }}>
            <Typography color="text.primary" variant="body2" fontWeight="bold">
              {`Розрахувати клас енергоефективності будівлі`}
            </Typography>
            <Typography
              pb={2}
              color="text.secondary"
              variant="body2"
              sx={{ my: 0.5 }}
            >
              {
                <>
                  {
                    "Форма допоможе визначити приблизний рівень енергоефективності за шкалою, затвердженою "
                  }
                  <Link
                    style={{ textDecoration: "none" }}
                    to={"https://zakon.rada.gov.ua/laws/show/z0822-18#Text"}
                  >
                    {"законодавством України. "}
                  </Link>
                  {"Вона не замінить повноцінного енергоаудиту!"}
                </>
              }
            </Typography>
            <Box
              sx={{
                display: "flex",
                flexDirection: "row",
                alignItems: "center",
              }}
            >
              <StepDropDown
                autofocus={true}
                setData={(event) =>
                  setCalculationMode(event.target.value as CalculationMode)
                }
                label={"Тип розрахунку:"}
                value={calculationMode}
                menuItems={[
                  {
                    label: "За фактичними показниками",
                    value: CalculationMode.EnergyMeter,
                  },
                  {
                    label: "За характеристиками будівлі",
                    value: CalculationMode.Specs,
                  },
                ]}
              />
              <Button
                sx={{ marginLeft: "20px", marginTop: "30px" }}
                onClick={handleStart}
                variant="contained"
              >
                {"Розрахувати"}
              </Button>
            </Box>
          </Box>
        </Box>
      </Card>
    </>
  );
};

export default StartCalculation;
