// //2)Second time  
// import { createReducer, on } from '@ngrx/store';
// import { EntityState } from '../store/datasettype.store';
// import { deleteSpecialtyAPISuccess, invokeDeleteSpecialtyAPI, invokeSaveNewSpecialtyAPI, invokeSpecialtysAPI, invokeUpdateSpecialtyAPI, saveNewSpecialtyAPISucess, specialtysFetchAPISuccess, updateSpecialtyAPISucess } from '../actions/specialty.action';



// export function createEntityReducer<T>(
//   entityName: string
// ): (
//   state: EntityState<T> | undefined,
//   action: any
// ) => EntityState<T> {
//   const initialState: EntityState<T> = {
//     data: null,
//     dataList: [],
//     success: false,
//     isLoading: false,
//     error: null,
//     message: null,
//     errors: null,
//     ids: [],
//   };

//   const entityReducer = createReducer(
//     initialState,

//     on(EntityActions.loadEntitiesSuccess, (state, { entities }) => ({
//       ...state,
//       entities: entities.reduce(
//         (acc, entity) => ({ ...acc, [entity.id]: entity }),
//         {}
//       ),
//       ids: entities.map(entity => entity.id)
//     })),

//     on(EntityActions.addEntitySuccess, (state, { entity }) => ({
//       ...state,
//       entities: { ...state.data, [entity.id]: entity },
//       ids: [...state.ids, entity.id]
//     })),

//     on(EntityActions.updateEntitySuccess, (state, { entity }) => ({
//       ...state,
//       entities: { ...state.dataList, [entity.id]: entity }
//     })),

//     on(EntityActions.deleteEntitySuccess, (state, { id }) => {
//       const { [Number(id)]: removedEntity, ...entities } = state.dataList;
//       const ids = state.ids.filter(entityId => entityId !== Number(id));

//       return {
//         ...state,
//         entities,
//         ids
//       };
//     })
//   );

//   return entityReducer;
// }
