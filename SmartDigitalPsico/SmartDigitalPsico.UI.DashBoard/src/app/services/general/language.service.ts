import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

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

  setInstant(infoKey: string): any {
    return this.translate.instant(infoKey)
  }

  setLanguage(lang: string) {

    this.removeLanguageToLocalStorage();
    console.log(this.translate.currentLang);

    if (this.translate.currentLang === 'pt-BR') {
      lang = 'en';
    } else {
      lang = 'pt-BR'; 
    }
    this.translate.use(lang);
    this.translate.setDefaultLang(lang);    
    console.log(lang);
    this.saveLanguageToLocalStorage(lang);

    window.location.reload();//paliativa
  }

  private saveLanguageToLocalStorage(lang: string) {
    localStorage.setItem(this.keyLanguage, lang);
  }
  private removeLanguageToLocalStorage() {
    localStorage.removeItem(this.keyLanguage);
  }
  private getLanguageToLocalStorage(): string {
    let result: string;
    result = localStorage.getItem(this.keyLanguage);

    if (result === undefined || result === null || result === '')
      return "en";

    return result;
  }
}
