import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import {
  FormGroup,
  FormBuilder,
  FormControl,
  Validators
} from "@angular/forms";
import { environment } from "../../environments/environment";
import urljoin from "url-join";

@Injectable()
export class BoardKnightService {
  /**
   *
   */

  endPoint: string;

  constructor(protected http: HttpClient) {
    this.endPoint = urljoin(environment.apiUrl, "boardknight");
  }

  getPossibleMoves(x: number, y: number, nMoves: number): Observable<string[]> {
    const requestUrl = urljoin(this.endPoint, this.getAlgebraicNotation(x, y + 1), "moves", nMoves.toString());
    return this.http.get<string[]>(requestUrl);
  }

  getAlgebraicNotation(x: number, y: number): string {
    return this.getLetter(x) + y.toString();
  }

  getLetter(x: number): string {
    return String.fromCharCode(97 + x);
  }
}
