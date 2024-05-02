# DevInterview

## Dev

1. Clonar el proyecto
2. Ejecutar `npm install`
3. Levantar backend
4. Ejecutar la app `npm start` o bien `ng serve -o`

## Angular Commands

ng serve

ng g m profile --routing
ng g component profile/layouts/profileLayout --inline-style --skip-tests
ng generate guard auth/guards/isAuthenticated --functional

ng g component auth/pages/loginPage --inline-style --skip-tests
ng g component auth/pages/registerPage --inline-style --skip-tests

ng g component applications/pages/applicationPage --inline-style --skip-tests
ng g component applications/pages/layoutPage --inline-style --skip-tests
ng g component applications/pages/listPage --inline-style --skip-tests
ng g component applications/pages/newPage --inline-style --skip-tests

ng g component shared/pages/error404Page --inline-style --skip-tests

ng g component jobapplications/components/card --inline-style --skip-tests

ng generate service auth/services/auth
