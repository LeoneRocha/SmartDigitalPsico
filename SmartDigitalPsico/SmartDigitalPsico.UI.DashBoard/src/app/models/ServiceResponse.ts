export interface ServiceResponse<T> {
  data: T;
  success: boolean;
  message: string;
  errors: ErroResponse[];
}
export interface ErroResponse {
  name: string;
  message: string;
}

export function GetMsgServiceResponse<T>(response: ServiceResponse<T>) {
  let messageResult: string = 'Ocorreu um erro!';

  if (response?.errors?.length > 0) {
    messageResult ='';
    response?.errors?.forEach(responseItem => {
      messageResult += ` O Campo: ${responseItem.name}. Detalhe: ${responseItem.message}`;
    });
  }
  return messageResult;
}