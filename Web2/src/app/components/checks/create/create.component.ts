import { Component, OnInit } from '@angular/core';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {


  week1RegHours = 0.0;
  week1OtHours = 0.0;
  week2RegHours = 0.0;
  week2OtHours = 0.0;
  rate = 21;
  regularPay = 840;
  overtimePay = 0;
  totalPay = 880.00;

  constructor() { }

  ngOnInit(): void {
  }

  generatePDF() {
    const element = document.getElementById('paycheck')!;
    html2canvas(element).then((canvas) => {
      const imgData = canvas.toDataURL('image/png');
      const pdf = new jsPDF();
      const imgProps = pdf.getImageProperties(imgData);
      const pdfWidth = pdf.internal.pageSize.getWidth();
      const pdfHeight = (imgProps.height * pdfWidth) / imgProps.width;
      pdf.addImage(imgData, 'PNG', 0, 0, pdfWidth, pdfHeight);
      pdf.save("paycheck.pdf");
    });
  }

}
