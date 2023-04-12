import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root'
})
export class LanguageService {
  constructor(private translate: TranslateService) {}

  setLanguage(lang: string) {
   // this.translate.use(lang);
   // this.translate.setDefaultLang(lang);

    if (this.translate.currentLang === 'pt-BR') {
      this.translate.use('en');
      this.translate.setDefaultLang('en');
    } else {
      this.translate.use(lang);//'pt-BR')
      this.translate.setDefaultLang(lang);//'en'); // define o idioma padrão
    }


  }

  ChangeLanguage(idLanguage: string, translate: TranslateService) {
    console.log(translate.currentLang);    
    if (translate.currentLang === 'pt-BR') {
      translate.use('en');
      translate.setDefaultLang('en');
    } else {
      translate.use(idLanguage);//'pt-BR')
      translate.setDefaultLang(idLanguage);//'en'); // define o idioma padrão
    }
    //https://localazy.com/p/smartdigitalpsico/phrases/1065/translate ou chat gpt
  }
}
