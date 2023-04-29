// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  production: false,
  EnableCaptureResponseTolog: true,
  APIUrl: 'https://localhost/api',// npm start  
  //APIUrl: 'https://localhost:57854/api',// npm start  
  //APIUrl: 'https://localhost:443/api',// DOCKER  
  //APIUrl: 'http://smartdigitalpsicapi.ddns.net/api',// DNS  
};
