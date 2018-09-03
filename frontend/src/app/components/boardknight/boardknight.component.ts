import { Component, OnInit } from "@angular/core";
import { BoardKnightService } from "../../services/boardknight.service";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: "app-boardknight",
  templateUrl: "./boardknight.component.html",
  styleUrls: ["./boardknight.component.scss"]
})
export class BoardknightComponent implements OnInit {
  constructor(
    private boardknightService: BoardKnightService,
    private toastrService: ToastrService
  ) {}

  boardSize = 8;
  result: string;

  board: number[][];
  nMoves = 1;

  resultList: string[];

  ngOnInit() {
    this.initBoard();
  }

  public getCoordinates(i, j) {
    this.boardknightService.getPossibleMoves(i, j, this.nMoves).subscribe(
      res => {
        this.result = res.join(",");
        this.resultList = res;
      },
      err => {
        console.log(err);
        this.toastrService.error(err.error);
      }
    );
  }

  initBoard() {
    this.board = new Array(this.boardSize);
    for (let i = 0; i < this.boardSize; i++) {
      const line = Array.from(Array(this.boardSize).keys());
      this.board[i] = line;
    }
  }

  getLetter(x: number): string {
    return this.boardknightService.getLetter(x);
  }

  invertYAxis(y: number): number {
    return this.board.length - (y + 1);
  }

  isResultCell(x, y): boolean {
    if (!this.resultList) {
      return false;
    }
    const cell = this.boardknightService.getAlgebraicNotation(x, y + 1);
    return this.resultList.indexOf(cell) !== -1;
  }
}
