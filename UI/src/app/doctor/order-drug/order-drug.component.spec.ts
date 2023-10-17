import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderDrugComponent } from './order-drug.component';

describe('OrderDrugComponent', () => {
  let component: OrderDrugComponent;
  let fixture: ComponentFixture<OrderDrugComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OrderDrugComponent]
    });
    fixture = TestBed.createComponent(OrderDrugComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
