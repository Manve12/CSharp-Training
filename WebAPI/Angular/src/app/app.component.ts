import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = "todo-list";
  todos = null;

  delete(id): void
  {
    this.http.delete('http://localhost:62876/api/Todo/'+id).subscribe(data => {
      location.reload();
    });
  }

  create(message): void
  {
    this.http.post('http://localhost:62876/api/Todo/Set?description='+message).subscribe();
  }

  save(id,message,status): void
  {
    this.http.put('http://localhost:62876/api/Todo/Update?Id='+id+'&description='+message+'&status='+status).subscribe(data => {
      location.reload();
    });
  }

   // Inject HttpClient into your component or service.
  constructor(private http: HttpClient) {}
  ngOnInit(): void {
    // Make the HTTP request:
    this.http.get('http://localhost:62876/api/Todo').subscribe(data => {
      this.todos = data;
    });
  }
}
