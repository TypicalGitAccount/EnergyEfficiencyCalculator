import { Box, TextField, Typography } from "@mui/material";
import React from "react";
import { NumericFormat } from "react-number-format";

interface NumberFieldProps {
  title: string;
  measuringUnits?: string;
  tooltip?: React.ReactNode;
  min: number;
  max: number;
  value: number;
  fullWidth?: boolean;
  setData: (val: number) => void;
}

const NumberField: React.FC<NumberFieldProps> = (props) => {
  const {
    title,
    min,
    max,
    setData,
    value,
    measuringUnits,
    tooltip,
    fullWidth,
  } = props;

  const handleChange = (event: React.FormEvent<any>) => {
    const value = event.currentTarget.value;
    let number = parseFloat(event.currentTarget.value);

    if (event.currentTarget.value.toString() !== "-") {
      if (number < min) {
        number = min;
      }
      if (number > max) {
        number = max;
      }
    }

    setData(value);
  };

  return (
    <Box
      sx={{
        mt: 1,
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
      }}
    >
      <Typography
        gutterBottom
        sx={{
          display: "flex",
          flexDirection: "row",
          color: "black.200",
          alignItems: "center",
        }}
        align="center"
      >
        {`${title}${measuringUnits !== undefined ? ", " + measuringUnits : ""}`}
        <div style={{ marginLeft: "5px" }}>{tooltip}</div>
      </Typography>
      <div>
        <TextField
          defaultValue={min}
          type="text"
          value={value}
          onChange={(e) => handleChange(e)}
          fullWidth={fullWidth}
          InputProps={{
            inputProps: {
              min: min,
              max: max,
            },
          }}
        />
      </div>
    </Box>
  );
};

NumberField.defaultProps = {
  fullWidth: true,
};

export default NumberField;
