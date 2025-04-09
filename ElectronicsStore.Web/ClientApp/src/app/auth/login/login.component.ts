import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AuthService, LoginCredentials } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone: true,
  imports: [FormsModule]
})
export class LoginComponent {
  credentials: LoginCredentials = {
    email: '',
    password: ''
  };

  constructor(private authService: AuthService, private router: Router) {}

  login() {
    this.authService.login(this.credentials).subscribe({
      next: (response: any) => {
        alert('Login successful!');
        localStorage.setItem('token', response.token);
        this.router.navigate(['/products']);
      },
      error: (err: any) => {
        alert('Login failed!');
        console.error(err);
      }
    });
  }
}
