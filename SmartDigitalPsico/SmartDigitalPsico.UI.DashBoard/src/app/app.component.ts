import { Component, Inject } from '@angular/core';
import { LanguageService } from './services/general/language.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {

  constructor(@Inject(LanguageService) private languageService: LanguageService) {
  }

  ChangeLanguage(idLanguage: string) {
    this.languageService.setLanguage(idLanguage);
  }
}
