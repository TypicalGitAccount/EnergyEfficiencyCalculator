import { toast } from "react-toastify";
import { AdviceCriteriaDto } from "./interfaces";

export const validateFilters = (data: AdviceCriteriaDto) => {
  if (data.minPrice >= data.maxPrice) {
    toast.error(
      "Мінімальна ціна не може бути більшою або рівною максимальній!"
    );

    return false;
  }

  if (data.minPrice < 0 || data.maxPrice < 0) {
    toast.error("Ціна не може бути нижчою нуля!");
    return false;
  }

  if (data.maxPrice.toString() === "") {
    toast.error("Вкажіть максимальну ціну!");
    return false;
  }

  if (data.minPrice.toString() === "") {
    toast.error("Вкажіть мінімальну ціну!");
    return false;
  }

  return true;
};
