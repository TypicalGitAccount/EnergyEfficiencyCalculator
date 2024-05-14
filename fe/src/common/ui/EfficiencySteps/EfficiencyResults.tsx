import { Box, Button, Card, Grid, Link, Typography } from "@mui/material";
import React from "react";
import {
  BuildingTypes,
  BuildingTypesToLabels,
  EfficiencyClass,
  EfficiencyClassToDesc,
  monthLabels,
} from "../../interfaces";
import Confirmation from "../Confirmation";

interface EfficiencyResultsProps {
  payments: number[];
  efficiencyClass: string;
  backToCalculationButton: React.ReactNode;
  buildingType: BuildingTypes;
  toBuildingAdvices: () => void;
  dropCalculation: () => void;
}

const EfficiencyResults: React.FC<EfficiencyResultsProps> = ({
  payments,
  efficiencyClass,
  backToCalculationButton,
  buildingType,
  toBuildingAdvices,
  dropCalculation,
}) => {
  const [confirmation, setConfirmation] = React.useState(false);

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
          marginTop: "120px",
        }}
      >
        <Box
          sx={{
            width: "100%",
            display: "flex",
            textAlign: "left",
            flexDirection: "column",
            alignItems: "center",
            gap: 2.5,
          }}
        >
          <Box
            sx={{
              width: "100%",
              display: "flex",
              textAlign: "left",
              flexDirection: "row",
              alignItems: "center",
              gap: 2.5,
            }}
          >
            <Box
              component="img"
              sx={{
                color: "primary.main",
                height: 350,
                width: 500,
              }}
              alt="Eneregy efficiency scale"
              src={`${process.env.PUBLIC_URL}/scale.png`}
            />

            <Box sx={{ textTransform: "none" }}>
              <h3>Останній розрахунок</h3>
              <Typography
                color="text.primary"
                variant="body2"
                fontWeight="bold"
                mt={2}
              >
                {`Клас загальної енергоефективності будівлі: ${efficiencyClass.toLocaleUpperCase()}`}
              </Typography>
              <Typography
                pb={2}
                color="text.secondary"
                variant="body2"
                sx={{ my: 0.5 }}
              >
                {EfficiencyClassToDesc.get(efficiencyClass as EfficiencyClass)}
              </Typography>
              <Typography
                color="text.primary"
                variant="body2"
                fontWeight="bold"
              >
                {`Приблизні витрати на опалення щомісяця:`}
              </Typography>
              <Grid container width={500} spacing={2} mt={0.5}>
                {payments.map((val, index) => (
                  <Grid item key={index} xs={4}>
                    <Typography color="text.primary" variant="body2">
                      {`${monthLabels[index]}: ${val} грн`}
                    </Typography>
                  </Grid>
                ))}
              </Grid>
            </Box>
          </Box>
          <Box pt={0} mb={4}>
            <Button
              onClick={() => setConfirmation(true)}
              sx={{ mr: 1 }}
              variant="contained"
            >
              Скинути
            </Button>
            <Button
              onClick={toBuildingAdvices}
              variant="contained"
              sx={{ mr: 1 }}
            >
              {`До рекомендацій за типом будівлі: ${BuildingTypesToLabels.get(
                buildingType
              )}`}
            </Button>
            {backToCalculationButton}
          </Box>
        </Box>
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
      </Card>
    </>
  );
};

export default EfficiencyResults;
