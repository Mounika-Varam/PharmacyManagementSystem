import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OutOfStockDrugsComponent } from './out-of-stock-drugs.component';

describe('OutOfStockDrugsComponent', () => {
  let component: OutOfStockDrugsComponent;
  let fixture: ComponentFixture<OutOfStockDrugsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OutOfStockDrugsComponent]
    });
    fixture = TestBed.createComponent(OutOfStockDrugsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
