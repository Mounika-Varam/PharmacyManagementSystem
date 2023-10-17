import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PickedUpOrdersComponent } from './picked-up-orders.component';

describe('PickedUpOrdersComponent', () => {
  let component: PickedUpOrdersComponent;
  let fixture: ComponentFixture<PickedUpOrdersComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PickedUpOrdersComponent]
    });
    fixture = TestBed.createComponent(PickedUpOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
