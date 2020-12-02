import { Injectable } from '@angular/core';

// source: https://github.com/dominiklessel/node-barcoder/blob/master/lib/barcoder.js

@Injectable({
  providedIn: 'root'
})
export class GtinService {
  private readonly validationRegex = /^(\d{12,14}|\d{8})$/;

  private static toInt(numString: string) {
    return parseInt(numString, 10);
  }

  private static isOdd(num: number): boolean {
    return (num % 2) === 1;
  }

  validate(barcode: string): boolean {
    if (this.validationRegex.exec(barcode) === null) {
      return false;
    }

    const checksum = GtinService.toInt(barcode.substring(barcode.length - 1));
    const calcChecksum = this.calculateChecksum(barcode);

    return (checksum === calcChecksum);
  }

  private calculateChecksum(gtin: string) {
    const chunks = gtin.split('').map(GtinService.toInt).reverse();
    let checksum = 0;

    // Remove first chuck (checksum)
    chunks.shift();

    // sum numbers and multiply accordingly
    chunks.forEach((number, index) => {
      checksum += GtinService.isOdd(index) ? number : number * 3;
    });

    // calc checksum
    checksum %= 10;
    checksum = (checksum === 0) ? 0 : (10 - checksum);

    return checksum;
  }
}
