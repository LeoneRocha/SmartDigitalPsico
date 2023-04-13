import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Observable, forkJoin, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LanguageService {

  private keyLanguage: string = "AppLanguageId";

  constructor(private translate: TranslateService) { }

  loadLanguage() {
    let lang: string;

    lang = this.getLanguageToLocalStorage();

    this.translate.use(lang);
    this.translate.setDefaultLang(lang);
  }

  translateInformation(infoKey: string): any {


    let result: string = '';
    //result = this.setInstant(infoKey);

    result = this.getTranslate(infoKey);

    //console.log(result);

    if (result === undefined || result === null || result === '') result = infoKey;

    return result;
  }



  translateInformationAsync(infoKeys: string[]): string[] {
    // console.log(infoKeys);
    let translatedInfo: string[] = [];
    //result = this.setInstant(infoKey);
    //const translations =   this.translateInformations(infoKeys).toPromise();
    this.translateInformations(infoKeys).subscribe((response: string[]) => {
      response.forEach(key => {
        translatedInfo.push(key);
      });
      //console.log(response);
    });    
    //console.log('after getTranslateAsync ');
    //console.log(translatedInfo);
    return translatedInfo;
  }
  getTranslates(infoKey: string | string[]): Observable<any> {
    return this.translate.get(infoKey);
  }

  translateInformations(infoKeys: string[]): Observable<string[]> {
    return this.translate.get(infoKeys).pipe(
      map(translations => {
        let translatedInfo: string[] = [];
        infoKeys.forEach(key => {
          translatedInfo.push(translations[key]);
        });
        return translatedInfo;
      })
    );
  }

  setInstant(infoKey: string): any {
    return this.translate.instant(infoKey);
  }
  getTranslate(infoKey: string): any {
    let result: string = '';
    this.translate.get(infoKey).subscribe((res: string) => {
      result = res;
      return result
    });
    return result;
  }

  setLanguage(lang: string) {
    this.removeLanguageToLocalStorage();

    if (this.translate.currentLang === 'pt-BR') {
      lang = 'en';
    } else {
      lang = 'pt-BR';
    }
    this.translate.use(lang);
    this.translate.setDefaultLang(lang);
    this.saveLanguageToLocalStorage(lang);

    window.location.reload();//paliativa
  }

  private saveLanguageToLocalStorage(lang: string) {
    localStorage.setItem(this.keyLanguage, lang);
  }
  private removeLanguageToLocalStorage() {
    localStorage.removeItem(this.keyLanguage);
  }
  getLanguageToLocalStorage(): string {
    let result: string;
    result = localStorage.getItem(this.keyLanguage);

    if (result === undefined || result === null || result === '')
      return "en";

    return result;
  }
  /*
  this.translate.get(infoKey).subscribe((res: string) => {
      //console.log(res);
      result = res;
      return result
  }); */
  /*  infoKeys.forEach(element => {
   let infoTranslated = response[element];
   result.push(infoTranslated);
 });
 .subscribe((res: string[]) => {
   console.log(res);
   infoKeys.forEach(element => {
     let infoTranslated = res[element];
     result.push(infoTranslated);
   });   translateInformations(infoKeys: string[]): Observable<string[]> {
 const observables = infoKeys.map(key => this.translate.get(key));
 return forkJoin(observables);
}
 });*/
}
