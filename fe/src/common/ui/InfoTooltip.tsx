import React, { useState } from "react";
import "react-tippy/dist/tippy.css";
import { Tooltip } from "react-tippy";
import HelpOutlineRoundedIcon from "@mui/icons-material/HelpOutlineRounded";

interface InfoTooltipProps {
  text: string;
}

const InfoTooltip: React.FC<InfoTooltipProps> = ({ text }) => {
  const [shown, setShown] = useState(false);

  return (
    <>
      <div
        onMouseEnter={() => setShown(true)}
        onMouseLeave={() => setShown(false)}
      >
        <HelpOutlineRoundedIcon
          sx={{ "&:hover": { color: "black" } }}
          fontSize="small"
          color="primary"
        />
        <Tooltip
          open={shown}
          title={text}
          position="top-start"
          trigger="mouseenter"
          interactive
          animation="shift"
          theme={"light"}
          arrow={true}
        />
      </div>
    </>
  );
};

export default InfoTooltip;
