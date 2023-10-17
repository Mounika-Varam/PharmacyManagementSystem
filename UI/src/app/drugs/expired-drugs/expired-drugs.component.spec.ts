import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExpiredDrugsComponent } from './expired-drugs.component';

describe('ExpiredDrugsComponent', () => {
  let component: ExpiredDrugsComponent;
  let fixture: ComponentFixture<ExpiredDrugsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExpiredDrugsComponent]
    });
    fixture = TestBed.createComponent(ExpiredDrugsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
