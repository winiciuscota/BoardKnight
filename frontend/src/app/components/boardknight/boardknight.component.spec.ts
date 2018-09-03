import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BoardknightComponent } from './boardknight.component';

describe('BoardknightComponent', () => {
  let component: BoardknightComponent;
  let fixture: ComponentFixture<BoardknightComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BoardknightComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BoardknightComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
