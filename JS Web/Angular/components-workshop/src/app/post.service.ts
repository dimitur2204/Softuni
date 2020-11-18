import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IPost } from './interfaces/post';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http:HttpClient) { }

  loadPosts(limit?:number):Observable<IPost[]>{
    return this.http.get<IPost[]>(environment.apiUrl + `/posts?limit=${limit}`);
  }
}
