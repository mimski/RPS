import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

type Move = 'Rock' | 'Paper' | 'Scissors';

const moveMap: Record<Move, number> = { Rock: 0, Paper: 1, Scissors: 2 };

@Component({
  selector: 'app-game',
  imports: [CommonModule, HttpClientModule],
  templateUrl: './game.component.html',
  styleUrl: './game.component.css',
})
export class GameComponent {
  result: any;

  constructor(private http: HttpClient) {}

  play(move: Move) {
    const moveIndex = moveMap[move];
    this.http
      .post<any>('http://localhost:7126/api/Game/Play', {
        playerMove: moveIndex,
      })
      .subscribe({
        next: (response) => (this.result = response),
        error: (error) => console.error(error),
      });
  }
}
