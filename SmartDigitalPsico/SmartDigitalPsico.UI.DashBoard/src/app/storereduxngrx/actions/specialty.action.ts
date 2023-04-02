import { createAction, props } from '@ngrx/store'; 
import { ServiceResponse } from 'app/models/ServiceResponse';
import { SpecialtyModel } from 'app/models/simplemodel/SpecialtyModel';

export const invokeSpecialtysAPI = createAction(
  '[Specialtys API] Invoke Specialtys Fetch API'
);

export const specialtysFetchAPISuccess = createAction(
  '[Specialtys API] Fetch API Success',
  props<{ allSpecialtys:  SpecialtyModel[] }>()
);

export const invokeSaveNewSpecialtyAPI = createAction(
  '[Specialtys API] Inovke save new Specialty api',
  props<{ newSpecialty: SpecialtyModel }>()
);

export const saveNewSpecialtyAPISucess = createAction(
  '[Specialtys API] save new Specialty api success',
  props<{ newSpecialty: SpecialtyModel}>()
);

export const invokeUpdateSpecialtyAPI = createAction(
  '[Specialtys API] Inovke update Specialty api',
  props<{ updateSpecialty: SpecialtyModel }>()
);

export const updateSpecialtyAPISucess = createAction(
  '[Specialtys API] update  Specialty api success',
  props<{ updateSpecialty: SpecialtyModel }>()
);

export const invokeDeleteSpecialtyAPI = createAction(
  '[Specialtys API] Inovke delete Specialty api',
  props<{id:number}>()
);

export const deleteSpecialtyAPISuccess = createAction(
  '[Specialtys API] deleted Specialty api success',
  props<{id:number}>()
);