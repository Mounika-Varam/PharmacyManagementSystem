import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DocNavbarComponent } from './doc-navbar.component';

describe('DocNavbarComponent', () => {
  let component: DocNavbarComponent;
  let fixture: ComponentFixture<DocNavbarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DocNavbarComponent]
    });
    fixture = TestBed.createComponent(DocNavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
