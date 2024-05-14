import { confirmAlert } from "react-confirm-alert";
import { PropsWithChildren } from "react";

interface ViewvedAdviceProps {
  onCloseView: () => void;
}

const ViewvedAdvice: React.FC<PropsWithChildren<ViewvedAdviceProps>> = ({
  onCloseView,
  children,
}) => {
  return (
    <>
      {confirmAlert({
        customUI: ({ onClose }) => {
          return children;
        },
        onClickOutside() {
          onCloseView();
        },
      })}
    </>
  );
};

export default ViewvedAdvice;
