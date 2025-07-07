# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/) and [Common Changelog](
https://common-changelog.org/).

This project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added

- Add custom request/handler implementation to replace MediatR

### Changed

- Update all endpoints to use the new request/handler implementation

### Removed

- Remove MediatR due to its new license structure

## [1.0.2] - 2025-06-17

### Removed

- Remove `millisecond()` field function support as it's not supported by Npgsql, the EFCore data source used

## [1.0.1] - 2025-05-23

### Fixed

- Fix error StatusCode not set properly

## [1.0.0] - 2025-05-07

Initial release.

[unreleased]: https://github.com/funql/funql-playground-api/compare/1.0.2...HEAD
[1.0.2]: https://github.com/funql/funql-playground-api/compare/1.0.1...1.0.2
[1.0.1]: https://github.com/funql/funql-playground-api/compare/1.0.0...1.0.1
[1.0.0]: https://github.com/funql/funql-playground-api/releases/tag/1.0.0