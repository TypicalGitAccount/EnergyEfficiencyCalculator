import {
  Box,
  InputLabel,
  MenuItem,
  Select,
  SelectChangeEvent,
} from "@mui/material";

export interface DropDownItem {
  value: any;
  label: string;
  underContent?: React.ReactNode;
}

interface StepDropDownProps {
  setData: (event: SelectChangeEvent<any>) => void;
  label: string;
  value: any;
  defaultValue?: any;
  fieldType?: "number" | "text";
  menuItems: DropDownItem[];
  isMultiple?: boolean;
  renderValues?: (selected: any[]) => React.ReactNode;
  tooltip?: React.ReactNode;
  autofocus?: boolean;
}

const StepDropDown: React.FC<StepDropDownProps> = (props) => {
  const {
    setData,
    label,
    value,
    fieldType,
    menuItems,
    isMultiple,
    renderValues,
    defaultValue,
    tooltip,
    autofocus,
  } = props;
  const selectedContent = menuItems.find(
    (item) => item.value === value
  )?.underContent;

  return (
    <Box
      sx={{
        mt: 1,
        maxWidth: "120",
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
      }}
    >
      <InputLabel
        sx={{ display: "flex", flexDirection: "row", color: "black" }}
      >
        {label}
        <div style={{ marginLeft: "5px" }}>{tooltip}</div>
      </InputLabel>

      <Select
        autoFocus={autofocus}
        MenuProps={{
          PaperProps: {
            style: {
              maxHeight: 200,
            },
          },
        }}
        type={fieldType}
        value={value}
        defaultValue={defaultValue ?? value}
        onChange={(val) => setData(val)}
        multiple={isMultiple}
        sx={{ mt: 1, maxWidth: 300 }}
        renderValue={
          isMultiple && renderValues
            ? (selected) => renderValues(selected)
            : undefined
        }
      >
        {menuItems.map((item) => (
          <MenuItem
            value={item.value}
            sx={{
              whiteSpace: "nowrap",
              overflow: "hidden",
              maxWidth: 300,
              mt: 1,
              textOverflow: "ellipsis",
              "&:hover": {
                overflow: "visible",
                whiteSpace: "normal",
              },
            }}
          >
            {item.label}
          </MenuItem>
        ))}
      </Select>
      {selectedContent}
    </Box>
  );
};

export default StepDropDown;

StepDropDown.defaultProps = {
  isMultiple: false,
};
