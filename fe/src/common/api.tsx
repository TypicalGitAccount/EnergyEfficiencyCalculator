import axios, { AxiosError, AxiosRequestConfig } from "axios";
import {
  AdviceCriteriaDto,
  AdviceDto,
  ApiResponse,
  EfficiencyMeterInputModel,
  EnergyEfficiencyInputModel,
  EnergyMeterEfficiencyModel,
  Jwts,
  PaymentsModel,
  User,
  UserUpdateDto,
} from "./interfaces";
import { processResponse } from "./http";
import {
  ADVICE_FILTERING_URL,
  ADVICE_URL,
  CHANGE_PASSWORD_URL,
  EFFICIENCY_METER_URL,
  EFFICIENCY_PAYMENTS_URL,
  EFFICIENCY_URL,
  GET_USERBY_ID_URL,
  LOGIN_URL,
  REFRESH_URL,
  REGISTER_URL,
  UPDATE_USER_URL,
} from "./urls";
import { validateFilters } from "./validation";

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

export const login = async (
  email: string,
  password: string
): Promise<Jwts | null> => {
  const response = await defaultFetch<Jwts>(LOGIN_URL, {
    method: "post",
    data: { email, password },
  });

  return processResponse(response);
};

export const register = async (
  email: string,
  name: string,
  password: string
): Promise<void | null> => {
  console.log(REGISTER_URL);
  const response = await defaultFetch<void>(REGISTER_URL, {
    method: "post",
    data: { email, name, password },
  });

  return processResponse(response);
};

export const refreshToken = async (
  email: string,
  tokens: Jwts
): Promise<Jwts | null> => {
  const response = await protectedFetch<Jwts>(REFRESH_URL, tokens.accessToken, {
    method: "post",
    data: {
      email,
      ...tokens,
    },
  });

  return processResponse(response);
};

export const changePassword = async (
  token: string,
  email: string,
  oldPassword: string,
  newPassword: string
): Promise<Jwts | null> => {
  const result = await protectedFetch<Jwts>(CHANGE_PASSWORD_URL, token, {
    method: "post",
    data: {
      email,
      oldPassword,
      newPassword,
    },
  });

  return processResponse(result);
};

export const getUser = async (
  token: string,
  id: string
): Promise<User | null> => {
  const response = await protectedFetch<User>(
    `${GET_USERBY_ID_URL(id)}`,
    token,
    {
      method: "get",
    }
  );

  return processResponse(response);
};

export const updateUser = async (
  token: string,
  user: UserUpdateDto
): Promise<string | null> => {
  const response = await protectedFetch<string>(UPDATE_USER_URL, token, {
    data: user,
    method: "put",
  });

  return processResponse(response);
};

export const getAdvices = async (
  token: string
): Promise<AdviceDto[] | null> => {
  const response = await protectedFetch<AdviceDto[]>(ADVICE_URL, token, {
    method: "get",
  });

  return processResponse(response);
};

export const createAdvice = async (
  token: string,
  advice: AdviceDto
): Promise<string | null> => {
  const response = await protectedFetch<string>(ADVICE_URL, token, {
    data: advice,
    method: "post",
  });

  return processResponse(response);
};

export const updateAdvice = async (
  token: string,
  advice: AdviceDto
): Promise<string | null> => {
  const response = await protectedFetch<string>(ADVICE_URL, token, {
    data: advice,
    method: "put",
  });

  return processResponse(response);
};

export const getAdvicesFor = async (
  token: string,
  model: AdviceCriteriaDto
): Promise<AdviceDto[] | null> => {
  if (validateFilters(model)) {
    const response = await protectedFetch<AdviceDto[]>(
      ADVICE_FILTERING_URL,
      token,
      {
        data: model,
        method: "post",
      }
    );

    return processResponse(response);
  }

  return null;
};

export const deleteAdvice = async (
  token: string,
  id: string
): Promise<string | null> => {
  const response = await protectedFetch<string>(ADVICE_URL + `/${id}`, token, {
    method: "delete",
  });

  return processResponse(response);
};

export const getEnergyEfficiencyClass = async (
  token: string,
  model: EnergyEfficiencyInputModel
): Promise<string | null> => {
  const response = await protectedFetch<string>(EFFICIENCY_URL, token, {
    data: model,
    method: "post",
  });

  return processResponse(response);
};

export const getEnergyEfficiencyClassFromMeter = async (
  token: string,
  model: EfficiencyMeterInputModel
): Promise<string | null> => {
  const response = await protectedFetch<string>(EFFICIENCY_METER_URL, token, {
    data: model,
    method: "post",
  });

  return processResponse(response);
};

export const getPayments = async (
  token: string,
  model: PaymentsModel
): Promise<number[] | null> => {
  const response = await protectedFetch<number[]>(
    EFFICIENCY_PAYMENTS_URL,
    token,
    {
      data: model,
      method: "post",
    }
  );

  return processResponse(response);
};
