import { Box, Button, Card, InputLabel, MenuItem, Select } from "@mui/material";
import RangeSlider from "../EfficiencySteps/NumberField";
import {
  AdviceCriteriaDto,
  BuildingTypes,
  BuildingTypesToLabels,
} from "../../interfaces";
import { produce } from "immer";

interface FiltersProps {
  data: AdviceCriteriaDto;
  setData: (data: AdviceCriteriaDto) => void;
  onFilter: () => void;
}

const Filters: React.FC<FiltersProps> = ({ data, setData, onFilter }) => {
  return (
    <Card
      variant="outlined"
      sx={{
        mb: 8,
        top: 0,
        height: "120px",
        width: "100%",
        background: "none",
        backgroundColor: "#F5F5F5",
        "&:hover": { backgroundColor: `#E0E0E0` },
        display: "flex",
        textAlign: "center",
        flexDirection: "row",
        alignItems: "center",
      }}
    >
      <Box
        sx={{
          width: "100%",
          height: "100px",
          display: "flex",
          textAlign: "center",
          flexDirection: "row",
          alignItems: "center",
          gap: 4,
          ml: 25,
          mr: 0,
          pr: 0,
        }}
      >
        <RangeSlider
          title={"Мінімальна ціна, грн"}
          min={0}
          max={data.maxPrice}
          value={data.minPrice}
          setData={(val: number) =>
            setData(
              produce(data, (draft) => {
                draft.minPrice = val;
              })
            )
          }
        />

        <RangeSlider
          title={"Максимальна ціна, грн"}
          min={0}
          max={50000000}
          value={data.maxPrice}
          setData={(val: number) =>
            setData(
              produce(data, (draft) => {
                draft.maxPrice = val;
              })
            )
          }
        />
        <Box>
          <InputLabel style={{ marginTop: "10px", color: "black" }}>
            {"Тип будівлі"}
          </InputLabel>
          <Select
            sx={{ mt: 1 }}
            value={data.buildingType}
            onChange={(val) =>
              setData(
                produce(data, (draft) => {
                  draft.buildingType = val.target.value as BuildingTypes;
                })
              )
            }
          >
            <MenuItem value={BuildingTypes.Any}>
              {BuildingTypesToLabels.get(BuildingTypes.Any)}
            </MenuItem>
            <MenuItem value={BuildingTypes.Private}>
              {BuildingTypesToLabels.get(BuildingTypes.Private)}
            </MenuItem>
            <MenuItem value={BuildingTypes.Common}>
              {BuildingTypesToLabels.get(BuildingTypes.Common)}
            </MenuItem>
            <MenuItem value={BuildingTypes.Hotel}>
              {BuildingTypesToLabels.get(BuildingTypes.Hotel)}
            </MenuItem>
            <MenuItem value={BuildingTypes.Educational}>
              {BuildingTypesToLabels.get(BuildingTypes.Educational)}
            </MenuItem>
            <MenuItem value={BuildingTypes.Preschool}>
              {BuildingTypesToLabels.get(BuildingTypes.Preschool)}
            </MenuItem>
            <MenuItem value={BuildingTypes.Healthcare}>
              {BuildingTypesToLabels.get(BuildingTypes.Healthcare)}
            </MenuItem>
            <MenuItem value={BuildingTypes.Trading}>
              {BuildingTypesToLabels.get(BuildingTypes.Trading)}
            </MenuItem>
          </Select>
        </Box>

        <Button
          variant="contained"
          onClick={onFilter}
          sx={{ marginTop: "20px" }}
        >
          Пошук
        </Button>
      </Box>
    </Card>
  );
};

export default Filters;
