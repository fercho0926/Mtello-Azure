import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-details-by-employee',
  templateUrl: './details-by-employee.component.html',
  styleUrls: ['./details-by-employee.component.scss']
})
export class DetailsByEmployeeComponent implements OnInit {

   employeeData = {
    Date: '4/26/2024',
    Name: 'Patricia Anderson',
    Page: 'ATC-09',
    Day1: 8.00,
    Day2: 8.00,
    Day3: 8.00,
    Day4: 8.00,
    Day5: 8.00,
    Day6: '-',
    Day7: '-',
    Total_hr: 40.00,
    Money: '$800.00',
    Wk1r: '-',
    Wk1o: '-',
    Wk2r: '-',
    Wk2o: '-',
    Rate: '$20.00',
    Reg: '$800.00',
    Ot: '$-',
    Total: '$800.00',
    Disc: '$200.00',
    Miscellaneous: '$-',
    Memo: 'Consultant',
    City: 'Daytona Beach',
    St: 'FL',
    Estado: 'GENERADO',
    Creado_por: 'PAOLA',
    Fecha_de_creacion: '4/26/2024',
    Modificado_por: 'TELLO',
    Fecha_de_modificacion: '4/28/2024'
  };
  


    displayedColumns: string[] = [
      'date', 'name', 'page', 'day1', 'day2', 'day3', 'day4', 'day5',
      'day6', 'day7', 'totalHr', 'money', 'wk1r', 'wk1o', 'wk2r',
      'wk2o', 'rate', 'reg', 'ot', 'total', 'disc', 'miscellaneous',
      'memo', 'city', 'st', 'estado', 'creadoPor', 'fechaDeCreacion',
      'modificadoPor', 'fechaDeModificacion'
    ];

    dataSource = [this.employeeData];



  constructor() { }

  ngOnInit(): void {
  }

}
