import * as React from "react";
import Box from "@mui/material/Box";
import Stepper from "@mui/material/Stepper";
import Step from "@mui/material/Step";
import StepButton from "@mui/material/StepButton";
import { Button, Container } from "@mui/material";
import Confirmation from "./Confirmation";

interface FormStepperProps {
  steps: { value: React.ReactNode; label: string }[];
  dropCalculation: () => void;
  onCalculation: () => void;
}

const FormStepper: React.FC<FormStepperProps> = ({
  steps,
  dropCalculation,
  onCalculation,
}) => {
  const [activeStep, setActiveStep] = React.useState(0);
  const [confirmation, setConfirmation] = React.useState(false);

  const totalSteps = () => {
    return steps.length;
  };

  const isLastStep = () => {
    return activeStep === totalSteps() - 1;
  };

  const handleNext = () => {
    const newActiveStep = isLastStep() ? activeStep : activeStep + 1;
    setActiveStep(newActiveStep);
  };

  const handleBack = () => {
    setActiveStep((prevActiveStep) => prevActiveStep - 1);
  };

  const handleStep = (step: number) => () => {
    setActiveStep(step);
  };

  return (
    <>
      <Box sx={{ width: "100%", mb: 15 }}>
        <Container maxWidth="xs">{steps[activeStep].value}</Container>
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
          <Button
            disabled={activeStep === 0}
            onClick={handleBack}
            sx={{ mr: 1 }}
            variant="contained"
          >
            Назад
          </Button>
          <Button
            onClick={handleNext}
            disabled={activeStep === steps.length - 1}
            sx={{ mr: 1 }}
            variant="contained"
          >
            Далі
          </Button>
          {activeStep === steps.length - 1 && (
            <Button onClick={onCalculation} variant="contained">
              Розрахувати
            </Button>
          )}
        </div>

        <Stepper sx={{}} nonLinear activeStep={activeStep}>
          {steps.map((_, index) => (
            <Step completed={false}>
              <StepButton color="inherit" onClick={handleStep(index)}>
                {steps[index].label}
              </StepButton>
            </Step>
          ))}

          <Box
            sx={{
              display: "flex",
              flexDirection: "row",
              pt: 2,
              position: "sticky",
            }}
          ></Box>
        </Stepper>
      </div>
    </>
  );
};

export default FormStepper;
