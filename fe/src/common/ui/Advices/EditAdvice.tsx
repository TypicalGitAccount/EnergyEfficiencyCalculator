import { LockOutlined, EditNote } from "@mui/icons-material";
import {
  Container,
  CssBaseline,
  Box,
  Avatar,
  Typography,
  TextField,
  Button,
  Select,
  MenuItem,
  InputLabel,
  TextareaAutosize,
} from "@mui/material";
import { useState } from "react";
import useAuthContext from "../../hooks/useAuthContext";
import {
  AdviceDto,
  BuildingTypes,
  BuildingTypesToLabels,
} from "../../interfaces";
import { createAdvice, updateAdvice } from "../../api";
import { toast } from "react-toastify";
import { produce } from "immer";
import { v4 as uuidv4 } from "uuid";
import RangeSlider from "../EfficiencySteps/NumberField";
import { useNavigate } from "react-router-dom";

interface EditAdviceProps {
  item: AdviceDto | null;
}

const EditAdvice: React.FC<EditAdviceProps> = ({ item }) => {
  const navigate = useNavigate();
  const { user, jwtTokens } = useAuthContext();
  const isUpdateForm = item !== null;
  const [advice, setAdvice] = useState<AdviceDto>(
    item ?? {
      id: uuidv4(),
      title: "",
      minPrice: 0,
      maxPrice: 0,
      recommendationText: "",
      buildingType: BuildingTypes.Private,
    }
  );

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    if (user?.role.includes("Admin")) {
      if (isUpdateForm) {
        const data = await updateAdvice(jwtTokens!.accessToken, advice);
        if (data) {
          navigate("/advices");
          window.location.reload();
        }
      } else {
        const data = await createAdvice(jwtTokens!.accessToken, advice);
        if (data) {
          navigate("/advices");
          window.location.reload();
        }
      }
    } else {
      toast.error(`Для цієї дії потрібно бути адміністратором!`);
    }
  };

  return (
    <>
      <Container maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            mt: 5,
            mb: 8,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            textAlign: "center",
            maxHeight: 800,
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: "primary.light" }}>
            <EditNote />
          </Avatar>
          <Typography variant="h5">
            {isUpdateForm ? "Редагувати рекомендацію" : "Створити рекомендацію"}
          </Typography>
          <form onSubmit={handleSubmit}>
            <Box sx={{ mt: 1 }}>
              <TextField
                margin="normal"
                required
                fullWidth
                label="Назва"
                autoFocus
                value={advice.title}
                onChange={(val) =>
                  setAdvice(
                    produce(advice, (draft) => {
                      draft.title = val.target.value;
                    })
                  )
                }
              />

              <RangeSlider
                title={"Максимальна ціна, $"}
                min={advice.minPrice}
                max={50000}
                value={advice.maxPrice}
                setData={(val) =>
                  setAdvice(
                    produce(advice, (draft) => {
                      draft.maxPrice = val;
                    })
                  )
                }
              />

              <RangeSlider
                title={"Мінімальна ціна, $"}
                min={0}
                max={advice.maxPrice}
                value={advice.minPrice}
                setData={(val) =>
                  setAdvice(
                    produce(advice, (draft) => {
                      draft.minPrice = val;
                    })
                  )
                }
              />

              <InputLabel style={{ marginTop: "10px" }}>
                {"Тип будівлі"}
              </InputLabel>
              <Select
                sx={{ mt: 1 }}
                value={advice.buildingType}
                onChange={(val) =>
                  setAdvice(
                    produce(advice, (draft) => {
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

              <InputLabel style={{ marginTop: "10px" }}>
                {"Текст рекомендації"}
              </InputLabel>
              <TextareaAutosize
                style={{
                  boxSizing: "border-box",
                  width: "320px",
                  fontFamily: "IBM Plex Sans, sans-serif",
                  fontSize: "0.875rem",
                  fontWeight: "400",
                  lineHeight: "1.5",
                  padding: "8px 12px",
                  borderRadius: "8px",
                  marginTop: "10px",
                }}
                maxRows={3}
                value={advice.recommendationText}
                onChange={(event) =>
                  setAdvice(
                    produce(advice, (draft) => {
                      draft.recommendationText = event.target.value;
                    })
                  )
                }
              />

              <Button
                fullWidth
                variant="contained"
                sx={{ mt: 3, mb: 2 }}
                type="submit"
              >
                {isUpdateForm ? "Змінити" : "Створити"}
              </Button>
            </Box>
          </form>
        </Box>
      </Container>
    </>
  );
};

export default EditAdvice;
