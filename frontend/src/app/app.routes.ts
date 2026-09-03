import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./features/form-builder/form-builder').then((m) => m.FormBuilderPage),
  },
  { path: '**', redirectTo: '' },
];
