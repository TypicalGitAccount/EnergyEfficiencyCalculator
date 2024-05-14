import { Checkbox, Grid, InputLabel, TextField } from "@mui/material";
import { monthLabels } from "../../interfaces";
import { produce } from "immer";

interface YearlyBooleanProps {
  label: string;
  values: boolean[];
  onUpdateValues: (values: boolean[]) => void;
  measuringUnits?: string;
}

const YearlyBoolean: React.FC<YearlyBooleanProps> = (props) => {
  const { values, label, measuringUnits, onUpdateValues } = props;

  const handleChange = (index: number) => {
    const updatedMonthValues = [...values];
    updatedMonthValues[index] = !updatedMonthValues[index];
    onUpdateValues(updatedMonthValues);
  };

  return (
    <>
      <InputLabel sx={{ mt: 4, mb: 2, color: "black" }}>{`${label}${
        measuringUnits !== undefined ? ", " + measuringUnits : ""
      }`}</InputLabel>
      <Grid container width={400} spacing={1} mb={4}>
        {values.map((_, index) => (
          <>
            <Grid item key={index} xs={3}>
              <InputLabel>{monthLabels[index]}</InputLabel>
              <Checkbox
                checked={values[index]}
                value={values[index]}
                onChange={() => handleChange(index)}
              />
            </Grid>
          </>
        ))}
      </Grid>
    </>
  );
};

export default YearlyBoolean;
