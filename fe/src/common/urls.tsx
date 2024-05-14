const baseUrl = "https://localhost:7197";

export const CHANGE_PASSWORD_URL = baseUrl + "/Auth/change-password";
export const LOGIN_URL = baseUrl + "/Auth/Login";
export const REFRESH_URL = baseUrl + "/Jwt";
export const REGISTER_URL = baseUrl + "/Auth/Register";
export const GET_USERBY_ID_URL = (id: string): string =>
  `${baseUrl}/User/${id}`;
export const UPDATE_USER_URL = baseUrl + "/User";
export const ADVICE_URL = baseUrl + "/Advice";
export const ADVICE_FILTERING_URL = baseUrl + "/Advice/GetFor";
export const EFFICIENCY_URL = baseUrl + "/EnergyEfficiency";
export const EFFICIENCY_METER_URL = baseUrl + "/EnergyEfficiency/GetFromMeter";
export const EFFICIENCY_PAYMENTS_URL = baseUrl + "/EnergyEfficiency/Payments";
