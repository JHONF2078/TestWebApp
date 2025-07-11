import { Component, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { CommonModule } from '@angular/common';
import { Subscription } from 'rxjs';
import { User } from '../../interface/user';
import { UserService } from '../../services/user-service';
import { MATERIAL_IMPORTS } from '../../../shared/material/material.component';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [CommonModule, ...MATERIAL_IMPORTS],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})
export class UserListComponent {
  private subscriptions: Subscription = new Subscription();

  public dataSource = new MatTableDataSource<User>();

  @ViewChild(MatSort) order!: MatSort;

  // Columnas mostradas en la tabla
  displayedColumns: string[] = ['id', 'name'];
  isLoading = false;

  constructor(private userService: UserService) {

  }

  ngOnInit(): void {
    this.loadAllUsers();
  }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  applyFilter(): void {
    this.loadAllUsers();

  }

  ngAfterViewInit() {
    this.dataSource.sort = this.order;
  }

  loadAllUsers(): void {
    this.isLoading = true; // ← Activar loader
    //carga los usuarios
    const usersSubscription = this.userService.getAllUsers(true).subscribe({
      next: (userList) => {
        this.dataSource.data = userList;
      },
      error: () => {
        this.isLoading = false;
      },
      complete: () => {
        this.isLoading = false; // ← Desactivar loader
      }
    });

    this.subscriptions.add(usersSubscription);
  }

}
