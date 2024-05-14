import axios, { AxiosError, AxiosRequestConfig } from "axios";
import { ApiResponse } from "./interfaces";
import { toast } from "react-toastify";

export const defaultFetch = async <T,>(
  url: string,
  config: AxiosRequestConfig = {}
): Promise<ApiResponse<T>> => {
  const defaultConfig: AxiosRequestConfig = {
    headers: {
      "Content-Type": "application/json",
    },
    ...config,
  };

  try {
    const response = await axios(url, defaultConfig);
    return { data: response.data, status: response.status };
  } catch (error) {
    if (axios.isAxiosError(error)) {
      const err = error as AxiosError;
      if (err.response?.data) {
        return {
          status: err.response.status,
          error: err.response.data || "Помилка обробки відповіді сервера!",
        };
      }
    }
    return { status: 500, error: "Помилка сервера!" };
  }
};

export const protectedFetch = async <T,>(
  url: string,
  token: string,
  config: AxiosRequestConfig = {}
): Promise<ApiResponse<T>> => {
  const authConfig: AxiosRequestConfig = {
    ...config,
    headers: {
      ...config.headers,
      Authorization: `Bearer ${token}`,
    },
  };
  return defaultFetch<T>(url, authConfig);
};

export const processResponse = <T,>(response: ApiResponse<T>): T | null => {
  if (response.status === 200 && "data" in response)
    return response.data !== undefined ? response.data : null;
  else {
    if ("error" in response) {
      if (typeof response.error === "object" && "errors" in response.error) {
        const errors = response.error.errors;
        let msg = "";
        for (const key in errors) {
          if (errors.hasOwnProperty(key)) {
            msg += errors[key];
          }
        }
        toast.error(`${msg}`);
      } else toast.error(`${response.error}`);
    } else {
      toast.error(`Unknown error!`);
    }
    return null;
  }
};
