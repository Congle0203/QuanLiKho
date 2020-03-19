import { Supplier } from '../models/supplier.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { PagingParams } from '../params/paging-params.model';
import { PaginatedResult } from '../models/pagination.model';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
  })

export class SupplierService {
  baseUrl = 'http://localhost:58406/api/Suppliers/';

  constructor(private http: HttpClient) {
  }

  getAll() {
      return this.http.get(this.baseUrl);
  }

  getAllPaging(page?: any, itemsPerPage?: any, pagingParams?: PagingParams): Observable<PaginatedResult<Supplier[]>> {
    const paginatedResult = new PaginatedResult<Supplier[]>();

    let params = new HttpParams();
    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }

    if (pagingParams != null) {
      params = params.append('keyword', pagingParams.keyword);
      params = params.append('sortKey', pagingParams.sortKey);
      params = params.append('sortValue', pagingParams.sortValue);
      params = params.append('searchKey', pagingParams.searchKey);
      params = params.append('searchValue', pagingParams.searchValue);
    }

    return this.http.get<Supplier[]>(this.baseUrl + 'getAllPaging', { observe: 'response', params })
      .pipe(
        map(response => {
          paginatedResult.result = response.body;
          if (response.headers.get('Pagination') != null) {
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
          }
          return paginatedResult;
        })
      );
  }

  getDetail(mancc: any) {
      return this.http.get(this.baseUrl + mancc);
  }

  addNew(supplier: Supplier) {
      return this.http.post(this.baseUrl, supplier);
  }

  update(supplier: Supplier) {
      return this.http.put(this.baseUrl+ '/' +supplier.mancc, supplier);
  }

  delete(mancc: any) {
      return this.http.delete(this.baseUrl + '/' + mancc);
  }

}
