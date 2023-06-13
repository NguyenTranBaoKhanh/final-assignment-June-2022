import React from 'react';
import { createReturn } from 'typescript';

export type PageType = {
    currentPage?: number;
    totalPage?: number;
    handleChange: (page: number) => void;
}

const Paging: React.FC<PageType> = ({ currentPage = 1, totalPage = 1, handleChange }) => {
    const prePageStyle = currentPage !== 1 ? 'pagination__link' : 'pagination__link link-disable';
    const nextPageStyle = currentPage + 1 <= totalPage ? 'pagination__link' : 'pagination__link link-disable';

    const pageStyle = (page: number) => {
        if (page === currentPage) return 'pagination__link link-active';
        return 'pagination__link';
    };

    const onPrev = (e) => {
        e.preventDefault();

        if (currentPage !== 1) {
            handleChange(currentPage - 1);
        }
    };

    const onNext = (e) => {
        e.preventDefault();

        if (currentPage + 1 <= totalPage) {
            handleChange(currentPage + 1);
        }
    };

    const onPageNumber = (e, page: number) => {
        e.preventDefault();
        handleChange(page);
    };

    const elementPagination = () => {
        if (totalPage < 4){
            return [...Array(totalPage).keys()]
        }
        else if (currentPage < 3){
            return [0, 1, 2]
        }else if (currentPage > totalPage - 3) {
            return [3, 2, 1].map(x => totalPage - x)
        }
        return [2, 1, 0].map(x => currentPage - x)
    }

    return (
        <div className="w-100 d-flex align-items-center mt-3">
            <ul className="pagination">
                <li className="intro-x">
                    <a onClick={onPrev} className={prePageStyle}>
                        Previous
                    </a>
                </li>
                
                {
                    elementPagination().map(i => (
                        <li key={i} className="intro-x">
                            <a onClick={e => onPageNumber(e, i + 1)} className={pageStyle(i + 1)}
                            >
                                {i + 1}
                            </a>
                        </li>
                    ))
                }
                    
                <li className="intro-x">
                    <a onClick={onNext} className={nextPageStyle}>Next</a>
                </li>

            </ul>
        </div>
    );
};

export default Paging;