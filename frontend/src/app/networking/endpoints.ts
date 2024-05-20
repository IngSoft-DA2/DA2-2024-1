export enum SessionEndpoints {
  LOGIN = '/api/sessions',
}

// PetEndpoints.GET_ALL
export enum PetEndpoints {
  GET_ALL = '/api/v2/pets',
  GET_BY_ID = '/api/pets/',
  /*
   Se puede utilizar `util` -> npm install util
   nos da un método format -> nos permite interpolar variables
    Ejemplo:
    GET_BY_ID = 'api/pets/%s'
    format(PetEndpoints.GET_BY_ID, '1') -> api/pets/1
    La otra forma de hacerlo es: `${PetEndpoints.GET_BY_ID}1`
*/
}
