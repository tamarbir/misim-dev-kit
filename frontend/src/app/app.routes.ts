import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./features/form-list/form-list').then((m) => m.FormList),
  },
  {
    path: 'forms/new',
    loadComponent: () => import('./features/form-builder/form-builder').then((m) => m.FormBuilderPage),
  },
  {
    path: 'forms/:id/edit',
    loadComponent: () => import('./features/form-builder/form-builder').then((m) => m.FormBuilderPage),
  },
  {
    path: 'forms/:id/fill',
    loadComponent: () => import('./features/form-fill/form-fill').then((m) => m.FormFill),
  },
  {
    path: 'forms/:id/submissions',
    loadComponent: () => import('./features/submission-list/submission-list').then((m) => m.SubmissionList),
  },
  {
    path: 'submissions/:id',
    loadComponent: () =>
      import('./features/submission-detail/submission-detail').then((m) => m.SubmissionDetailPage),
  },
  { path: '**', redirectTo: '' },
];
