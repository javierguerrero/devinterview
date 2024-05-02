import { Component, computed, inject } from '@angular/core';
import { AuthService } from 'src/app/auth/services/auth.service';

@Component({
  selector: 'app-profile-layout',
  standalone: true,
  imports: [],
  templateUrl: './profile-layout.component.html',
  styles: ``,
})
export class ProfileLayoutComponent {
  private authService = inject(AuthService);
  public user = computed(() => this.authService.currentUser());
 
  onLogout(){
    
  }

}
