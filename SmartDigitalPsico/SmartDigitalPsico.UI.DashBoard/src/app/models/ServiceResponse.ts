import { ErroResponse } from "./general/ErroResponse";

export interface ServiceResponse<T> {
  data: T;
  success: boolean;
  message: string;
  errors: ErroResponse[];
} 