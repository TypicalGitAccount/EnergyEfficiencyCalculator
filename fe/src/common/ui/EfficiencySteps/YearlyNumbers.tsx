import { Grid, InputLabel, TextField } from "@mui/material";
import { monthLabels } from "../../interfaces";

interface YearlyNumbersProps {
  label: string;
  values: number[];
  onUpdateValues: (values: number[]) => void;
  minValue: number;
  maxValue: number;
  defaultValue: number;
  measuringUnits?: string;
}

const YearlyNumbers: React.FC<YearlyNumbersProps> = (props) => {
  const {
    values,
    onUpdateValues,
    minValue,
    maxValue,
    label,
    defaultValue,
    measuringUnits,
  } = props;

  const handleChange = (event: React.FormEvent<any>, index: number) => {
    const value = event.currentTarget.value;
    let number = parseFloat(event.currentTarget.value);

    if (event.currentTarget.value.toString() !== "-") {
      if (number < minValue) {
        number = minValue;
      }
      if (number > maxValue) {
        number = maxValue;
      }
    }

    const updatedMonthValues = [...values];
    updatedMonthValues[index] = isNaN(number) ? value : number;
    onUpdateValues(updatedMonthValues);
  };

  return (
    <Grid container width={400} spacing={2} mt={2}>
      <InputLabel sx={{ ml: 3, color: "black" }}>{`${label}${
        measuringUnits !== undefined ? ", " + measuringUnits : ""
      }`}</InputLabel>
      {values.map((_, index) => (
        <Grid item key={index} xs={3}>
          <TextField
            defaultValue={defaultValue}
            label={monthLabels[index]}
            type="number"
            value={values[index]}
            onChange={(event) => handleChange(event, index)}
            fullWidth
            InputProps={{
              inputProps: {
                min: minValue,
                max: maxValue,
              },
            }}
          />
        </Grid>
      ))}
    </Grid>
  );
};

export default YearlyNumbers;
