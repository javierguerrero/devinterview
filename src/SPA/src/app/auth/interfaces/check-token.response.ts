import { User } from './user.interface';

export interface CheckTokenResponse {
  user: User;
  accessToken: string;
  refreshToken: string;
}
