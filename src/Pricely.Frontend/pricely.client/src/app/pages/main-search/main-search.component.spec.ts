import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MainSearchComponent } from './main-search.component';

describe('MainSearchComponent', () => {
  let component: MainSearchComponent;
  let fixture: ComponentFixture<MainSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MainSearchComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MainSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
