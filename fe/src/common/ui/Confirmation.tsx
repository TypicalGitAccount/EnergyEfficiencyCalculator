import { Button } from "@mui/material";
import { confirmAlert } from "react-confirm-alert";

interface ConfirmationProps {
  title: React.ReactNode;
  declineContent: React.ReactNode;
  confirmContent: React.ReactNode;
  onDecline: () => void;
  onConfirm: () => void;
}

const Confirmation: React.FC<ConfirmationProps> = ({
  title,
  declineContent,
  confirmContent,
  onDecline,
  onConfirm,
}) => {
  return (
    <>
      {confirmAlert({
        customUI: ({ onClose }) => {
          return (
            <div
              className="custom-ui"
              onBlur={() => {
                onDecline();
                onClose();
              }}
              style={{
                textAlign: "center",
              }}
            >
              <h1>{title}</h1>

              <Button
                variant="contained"
                color="primary"
                onClick={() => {
                  onDecline();
                  onClose();
                }}
              >
                {declineContent}
              </Button>
              <Button
                sx={{ marginLeft: "20px" }}
                variant="contained"
                color="primary"
                onClick={async () => {
                  onConfirm();
                  onClose();
                }}
              >
                {confirmContent}
              </Button>
            </div>
          );
        },
      })}
    </>
  );
};

export default Confirmation;
